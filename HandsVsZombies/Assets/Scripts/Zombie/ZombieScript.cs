using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    private class BoneTransform
    {
        public Vector3 Position { get; set; }

        public Quaternion Rotation { get; set; }
    }

    private enum ZombieState
    {
        Walking,
        Ragdoll,
        StandingUp,
        ResettingBones
    }

    [SerializeField]
    private string _standUpStateName;

    [SerializeField]
    private string _standUpClipName;

    [SerializeField]
    private float _timeToResetBones;

    private Rigidbody[] _ragdollRigidbodies;
    private ZombieState _currentState = ZombieState.Walking;
    private NavMeshAgent navMeshAgent;
    private Animator _animator;
    private float _timeToWakeUp;
    private Transform _hipsBone;
    
    private Vector2 velocity;
    private Vector2 smoothDeltaPosition;

    private BoneTransform[] _standUpBoneTransforms;
    private BoneTransform[] _ragdollBoneTransforms;
    private Transform[] _bones;
    private float _elapsedResetBonesTime;
    private bool canStandUp = true;

    public Transform MovePositionTransform;


    void Awake()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        _animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        _hipsBone = _animator.GetBoneTransform(HumanBodyBones.Hips);

        _bones = _hipsBone.GetComponentsInChildren<Transform>();
        _standUpBoneTransforms = new BoneTransform[_bones.Length];
        _ragdollBoneTransforms = new BoneTransform[_bones.Length];

        for (int boneIndex = 0; boneIndex < _bones.Length; boneIndex++)
        {
            _standUpBoneTransforms[boneIndex] = new BoneTransform();
            _ragdollBoneTransforms[boneIndex] = new BoneTransform();
        }

        PopulateAnimationStartBoneTransforms(_standUpClipName, _standUpBoneTransforms);

        DisableRagdoll();
    }

    private void Start()
    {
        navMeshAgent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_currentState)
        {
            case ZombieState.Walking:
                WalkingBehaviour();
                break;
            case ZombieState.Ragdoll:
                RagdollBehaviour();
                break;
            case ZombieState.StandingUp:
                StandingUpBehaviour();
                break;
            case ZombieState.ResettingBones:
                ResettingBonesBehaviour();
                break;
        }
    }
    
    private void SynchonizeAnimatorAndAgent()
    {
        Vector3 worldDeltaPosition = navMeshAgent.nextPosition - transform.position;
        worldDeltaPosition.y = 0;

        float deltaX = Vector3.Dot(transform.right, worldDeltaPosition);
        float deltaY = Vector3.Dot(transform.forward, worldDeltaPosition);

        Vector2 deltaPosition = new Vector2(deltaX, deltaY);

        float smooth = Mathf.Min(1, Time.deltaTime / 0.1f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        velocity = smoothDeltaPosition / Time.deltaTime;

        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            velocity = Vector2.Lerp(
                Vector2.zero,
                velocity,
                navMeshAgent.remainingDistance / navMeshAgent.stoppingDistance
                );
        }

        bool shouldMove = velocity.magnitude > 0.5f
            && navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance;

        _animator.SetBool("move", shouldMove);
        _animator.SetFloat("locomotion", velocity.magnitude);

        float deltaMagitude = worldDeltaPosition.magnitude;
        if(deltaMagitude > navMeshAgent.radius / 2f)
        {
            transform.position = Vector3.Lerp(
                _animator.rootPosition,
                navMeshAgent.nextPosition,
                smooth);
        }
    }

    public void TriggerRagdoll()
    {
        EnableRagdoll();

        _currentState = ZombieState.Ragdoll;
        _timeToWakeUp = Random.Range(2, 3);
        navMeshAgent.enabled = false;
    }

    private void DisableRagdoll()
    {
        _animator.enabled = true;
    }

    public void EnableRagdoll()
    {
        _animator.enabled = false;
    }

    public void Grabbed()
    {
        canStandUp = false;
        TriggerRagdoll();
    }

    public void Released()
    {
        canStandUp = true;
    }

    private void WalkingBehaviour()
    {
        if (navMeshAgent.isActiveAndEnabled)
        {
            navMeshAgent.destination = MovePositionTransform.position;
        }
        //_hipsBone.position = new Vector3(transform.position.x, transform.position.y - navMeshAgent.baseOffset, transform.position.z);
        //SynchonizeAnimatorAndAgent();
    }

    private void RagdollBehaviour()
    {
        if (canStandUp)
        {
            _timeToWakeUp -= Time.deltaTime;

            if (_timeToWakeUp <= 0)
            {
                AlignRotationToHips();
                AlignPositionToHips();

                PopulateBoneTransforms(_ragdollBoneTransforms);

                _currentState = ZombieState.ResettingBones;
                _elapsedResetBonesTime = 0;
            }
        }
    }

    private void StandingUpBehaviour()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_standUpStateName) == false)
        {
            _currentState = ZombieState.Walking;
            navMeshAgent.enabled = true;
        }
    }

    private void ResettingBonesBehaviour()
    {
        _elapsedResetBonesTime += Time.deltaTime;
        float elapsedPercentage = _elapsedResetBonesTime / _timeToResetBones;

        for (int boneIndex = 0; boneIndex < _bones.Length; boneIndex++)
        {
            _bones[boneIndex].localPosition = Vector3.Lerp(
                _ragdollBoneTransforms[boneIndex].Position,
                _standUpBoneTransforms[boneIndex].Position,
                elapsedPercentage);

            _bones[boneIndex].localRotation = Quaternion.Slerp(
                _ragdollBoneTransforms[boneIndex].Rotation,
                _standUpBoneTransforms[boneIndex].Rotation,
                elapsedPercentage);
        }

        if (elapsedPercentage >= 1)
        {
            _currentState = ZombieState.StandingUp;
            DisableRagdoll();

            _animator.Play(_standUpStateName, -1, 0f);
        }
    }

    private void AlignRotationToHips()
    {
        Vector3 originalHipsPosition = _hipsBone.position;
        Quaternion originalHipsRotation = _hipsBone.rotation;

        Vector3 desiredDirection = _hipsBone.up * -1;
        desiredDirection.y = 0;
        desiredDirection.Normalize();

        Quaternion fromToRotation = Quaternion.FromToRotation(transform.forward, desiredDirection);
        transform.rotation *= fromToRotation;

        _hipsBone.position = originalHipsPosition;
        _hipsBone.rotation = originalHipsRotation;
    }

    private void AlignPositionToHips()
    {
        Debug.Log("[Zombie] AlignPositionToHips");
        Vector3 originalHipsPosition = _hipsBone.position;
        transform.position = _hipsBone.position;

        /*
        Vector3 positionOffset = _standUpBoneTransforms[0].Position;
        positionOffset.y = 0;
        positionOffset = transform.rotation * positionOffset;
        transform.position -= positionOffset;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo))
        {
            transform.position = new Vector3(transform.position.x, hitInfo.point.y, transform.position.z);
        }

        _hipsBone.position = originalHipsPosition;
        */
    }

    private void PopulateBoneTransforms(BoneTransform[] boneTransforms)
    {
        for (int boneIndex = 0; boneIndex < _bones.Length; boneIndex++)
        {
            boneTransforms[boneIndex].Position = _bones[boneIndex].localPosition;
            boneTransforms[boneIndex].Rotation = _bones[boneIndex].localRotation;
        }
    }

    private void PopulateAnimationStartBoneTransforms(string clipName, BoneTransform[] boneTransforms)
    {
        Vector3 positionBeforeSampling = transform.position;
        Quaternion rotationBeforeSampling = transform.rotation;

        foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
        {
            if (clip.name == clipName)
            {
                clip.SampleAnimation(gameObject, 0);
                PopulateBoneTransforms(_standUpBoneTransforms);
                break;
            }
        }

        transform.position = positionBeforeSampling;
        transform.rotation = rotationBeforeSampling;
    }
}