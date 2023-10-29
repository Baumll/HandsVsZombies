using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{

    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private Vector2 velocity;
    private Vector2 smoothDeltaPosition;

    public Transform MovePositionTransform { get => movePositionTransform; set => movePositionTransform = value; }

    private void Awake()
    {
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
        
    }

    // Update is called once per frame
    void Update()
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
}
