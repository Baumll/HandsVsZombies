using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    public enum ZombieState
    {
        Walking,
        Ragdoll
    }
    //For ragdoll
    private Rigidbody[] ragdollRigidbodyList;
    private CharacterJoint[] characterJointyList;
    private List<GameObject> characterJointGameobjectList;
    public ZombieState currentState = ZombieState.Walking;

    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private Vector2 velocity;
    private Vector2 smoothDeltaPosition;

    public Transform MovePositionTransform { get => movePositionTransform; set => movePositionTransform = value; }

    //LimbRenderer
    public GameObject LUpperLeg;
    public GameObject LCalve;
    public GameObject RUpperLeg;
    public GameObject RCalve;
    public GameObject LUpperArm;
    public GameObject LWrist;
    public GameObject LHand;
    public GameObject RUpperArm;
    public GameObject RWrist;
    public GameObject RHand;
    public GameObject Head;

    private void Awake()
    {
        ragdollRigidbodyList = GetComponentsInChildren<Rigidbody>();
        characterJointyList = GetComponentsInChildren<CharacterJoint>();

        

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = navMeshAgent.GetComponent<Animator>();

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

        animator.SetBool("move", shouldMove);
        animator.SetFloat("locomotion", velocity.magnitude);

        float deltaMagitude = worldDeltaPosition.magnitude;
        if(deltaMagitude > navMeshAgent.radius / 2f)
        {
            transform.position = Vector3.Lerp(
                animator.rootPosition,
                navMeshAgent.nextPosition,
                smooth);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var joint in characterJointyList)
        {
            characterJointGameobjectList.Add(joint.gameObject);
        }
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
        }

    }

    private void FixedUpdate()
    {

        List<GameObject> ceepList = new List<GameObject>();
        foreach (var limb in characterJointGameobjectList)
        {
            CharacterJoint joint = limb.GetComponent<CharacterJoint>();
            if (joint == null)
            {
                Debug.Log("Kaputt :(");
                switch (limb.name)
                {
                    case "Base HumanLLegThigh":

                        break;

                    case "Base HumanRLegThigh":
                        break;

                    case "Base HumanLArmUpperarm":
                        break;

                    case "Base HumanRArmUpperarm":
                        break;

                    case "Base HumanHead":
                        break;
                        
                }
                //jointObject.SetActive(false);
            }
            else
            {
                ceepList.Add(limb);
            }
        }
        characterJointGameobjectList = ceepList;
    }

    private void DisableRagdoll()
    {
        foreach (var rigidtbody in ragdollRigidbodyList)
        {
            if (rigidtbody)
            {
                rigidtbody.isKinematic = true;
            }

        }
    }

    private void EnanbleRagdoll()
    {
        foreach (var rigidtbody in ragdollRigidbodyList)
        {
            if (rigidtbody)
            {
                rigidtbody.isKinematic = false;
            }
        }
    }


    private void WalkingBehavior()
    {
        if (movePositionTransform)
        {
            navMeshAgent.destination = movePositionTransform.position;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.enabled = false;
            }
        }
    }

    private void RagdollBehavior()
    {
    }
}
