using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class ZombieScriptBackup : MonoBehaviour
{

    private class BoneTransform
    {
        public Vector3 position { get; set; }
        public Quaternion rotation { get; set; }
    }

    public enum ZombieState
    {
        Walking,
        Ragdoll,
        Crawling,
        StandingUp,
        ResettingBones,
    }
    //For ragdoll
    private Rigidbody[] ragdollRigidbodyList;
    private GrabAbleItem[] grabAbleItemList;
    private CharacterJoint[] characterJointyList;
    private List<GameObject> characterJointGameobjectList;
    public ZombieState currentState = ZombieState.Walking;
    [SerializeField] private float timeToWakeUp = 3f;
    private float deltaTimeRoWakeUp = 0;
    private Transform hipsBone;
    private BoneTransform[] standUpBoneTransformList;
    private BoneTransform[] ragdollBoneTransformList;
    private Transform[] boneList;

    [SerializeField] private string standUpStateName;
    [SerializeField] private string standUpClipName;
    [SerializeField] private float timeToResetBones;
    private float deltaTimeResetBones;
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    //private CharacterController characterController;

    private Vector2 velocity;
    private Vector2 smoothDeltaPosition;

    public Transform MovePositionTransform { get => movePositionTransform; set => movePositionTransform = value; }

    //LimbRenderer
    public bool crawl;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        ragdollRigidbodyList = GetComponentsInChildren<Rigidbody>();
        characterJointyList = GetComponentsInChildren<CharacterJoint>();
        grabAbleItemList = GetComponentsInChildren<GrabAbleItem>();
        hipsBone = animator.GetBoneTransform(HumanBodyBones.Hips);

        //characterController = GetComponent<CharacterController>();

        boneList = hipsBone.GetComponentsInChildren<Transform>();
        standUpBoneTransformList = new BoneTransform[boneList.Length];
        ragdollBoneTransformList = new BoneTransform[boneList.Length];

        for ( int boneIndex = 0; boneIndex < boneList.Length; boneIndex++)
        {
            standUpBoneTransformList[boneIndex] = new BoneTransform();
            ragdollBoneTransformList[boneIndex] = new BoneTransform();
        }

        PopulateAnimationStartBoneTransformList(standUpClipName, standUpBoneTransformList);

        animator.applyRootMotion = true;
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateRotation = true;
    }

    private void OnAnimatorMove()
    {
        Vector3 rootPosition = animator.rootPosition;
        rootPosition.y = navMeshAgent.nextPosition.y;
        transform.position = rootPosition;
        navMeshAgent.nextPosition = rootPosition;
    }

    //private void SynchonizeAnimatorAndAgent()
    //{
    //    Vector3 worldDeltaPosition = navMeshAgent.nextPosition - transform.position;
    //    worldDeltaPosition.y = 0;

    //    float deltaX = Vector3.Dot(transform.right, worldDeltaPosition);
    //    float deltaY = Vector3.Dot(transform.forward, worldDeltaPosition);

    //    Vector2 deltaPosition = new Vector2(deltaX, deltaY);

    //    float smooth = Mathf.Min(1, Time.deltaTime / 0.1f);
    //    smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

    //    velocity = smoothDeltaPosition / Time.deltaTime;

    //    if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
    //    {
    //        velocity = Vector2.Lerp(
    //            Vector2.zero,
    //            velocity,
    //            navMeshAgent.remainingDistance / navMeshAgent.stoppingDistance
    //            );
    //    }

    //    bool shouldMove = velocity.magnitude > 0.5f
    //        && navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance;

    //    animator.SetBool("move", shouldMove);
    //    animator.SetFloat("locomotion", velocity.magnitude);

    //    float deltaMagitude = worldDeltaPosition.magnitude;
    //    if(deltaMagitude > navMeshAgent.radius / 2f)
    //    {
    //        transform.position = Vector3.Lerp(
    //            animator.rootPosition,
    //            navMeshAgent.nextPosition,
    //            smooth);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case ZombieState.Walking:
                WalkingBehavior();
                break;
            case ZombieState.Ragdoll:
                RagdollBehavior();
                break;
            case ZombieState.StandingUp:
                StandingUpBehavior();
                break;
            case ZombieState.ResettingBones:
                ResetBonesBehavior();
                break;
        }

    }

    public void DisableRagdoll()
    {
        Debug.Log("Stand Up");
        animator.enabled = true;
        currentState = ZombieState.StandingUp;
        foreach (var rigidtbody in ragdollRigidbodyList)
        {
            if (rigidtbody)
            {
                //rigidtbody.isKinematic = true;
            }
        }
    }

    public void EnanbleRagdoll()
    {
        Debug.Log("Ragdoll");
        animator.enabled = false;
        currentState = ZombieState.Ragdoll;
        deltaTimeRoWakeUp = 0;
        foreach (var rigidtbody in ragdollRigidbodyList)
        {
            if (rigidtbody)
            {
                //rigidtbody.isKinematic = false;
            }
        }
    }


    private void WalkingBehavior()
    {
        if (movePositionTransform && navMeshAgent)
        {
            if (navMeshAgent.isActiveAndEnabled)
            {
                navMeshAgent.destination = movePositionTransform.position;
            }
            if (Vector3.Distance(MovePositionTransform.position, transform.position) < .1f)
            {
                animator.SetTrigger("Stop");
            }
            else
            {
                animator.SetTrigger("Go");
            }
        }
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            EnanbleRagdoll();
        }
    }

    private void RagdollBehavior()
    {
        if(transform.root.parent == null) { 
            deltaTimeRoWakeUp += Time.deltaTime;
            if (deltaTimeRoWakeUp > timeToWakeUp)
            {
                AlignRotationToHibs();
                AlignPositionToHibs();
                
                PopulateBoneTransforms(ragdollBoneTransformList);

                currentState = ZombieState.ResettingBones;
                deltaTimeResetBones = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            AlignRotationToHibs();
            AlignPositionToHibs();

            currentState = ZombieState.ResettingBones;
            PopulateBoneTransforms(ragdollBoneTransformList);
            deltaTimeResetBones = 0;
        }

    }

    private void StandingUpBehavior()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(standUpStateName) == false) 
        {
            currentState = ZombieState.Walking;    
        }
    }

    private void ResetBonesBehavior()
    {
        deltaTimeResetBones += Time.deltaTime;
        float elapsedPercentage = deltaTimeResetBones / timeToResetBones;

        for (int boneIndex = 0; boneIndex < boneList.Length; boneIndex++)
        {
            boneList[boneIndex].localPosition = Vector3.Lerp(
                ragdollBoneTransformList[boneIndex].position,
                standUpBoneTransformList[boneIndex].position,
                elapsedPercentage
                );

            boneList[boneIndex].localRotation = Quaternion.Lerp(
                ragdollBoneTransformList[boneIndex].rotation,
                standUpBoneTransformList[boneIndex].rotation,
                elapsedPercentage
                );
        }

        if(elapsedPercentage >= 1) {
            AlignPositionToHibs();
            DisableRagdoll();
            animator.Play(standUpStateName);
        }
    }

    public void LoseLeg()
    {
        crawl = true;
        animator.SetTrigger("LoseLeg");
    }

    private void AlignRotationToHibs()
    {
        Vector3 originalHipsPosition = hipsBone.position;
        Quaternion originalHipsRotation = hipsBone.rotation;

        Vector3 desiredDirection = hipsBone.up * -1;
        desiredDirection.y = 0;
        desiredDirection.Normalize();

        Quaternion fromToRotation = Quaternion.FromToRotation(transform.forward, desiredDirection);
        transform.rotation *= fromToRotation;

        hipsBone.position = originalHipsPosition;
        hipsBone.rotation = originalHipsRotation;
    }

    private void AlignPositionToHibs()
    {
        Vector3 originalHipsPostion = hipsBone.position;
        transform.position = hipsBone.position;

        Vector3 positionOffset = standUpBoneTransformList[0].position;
        positionOffset.y = 0;
        positionOffset = transform.rotation * positionOffset;
        transform.position -= positionOffset;

        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitInfo))
        {
            transform.position = new Vector3(transform.position.x, hitInfo.point.y, transform.position.z);
        }

        hipsBone.position = originalHipsPostion;
    }

    private void PopulateBoneTransforms(BoneTransform[] boneTransformList)
    {
        for (int boneIndex = 0; boneIndex < boneList.Length; boneIndex++)
        {
            boneTransformList[boneIndex].position = boneList[boneIndex].localPosition;
            boneTransformList[boneIndex].rotation = boneList[boneIndex].localRotation;
        }
    }

    private void PopulateAnimationStartBoneTransformList( string clipName, BoneTransform[] boneTransforms)
    {
        Vector3 positionBeforSampling = transform.position;
        Quaternion rotationBeforSampling = transform.rotation;

        foreach(AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if(clip.name == clipName)
            {
                clip.SampleAnimation(gameObject, 0);
                PopulateBoneTransforms(standUpBoneTransformList);
                break;
            }
        }

        transform.position = positionBeforSampling;
        transform.rotation = rotationBeforSampling;
    }

}
