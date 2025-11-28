using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;

public class SkeletonAI : MonoBehaviour
{
    public Transform player; // Drag your target GameObject here in the Inspector
    private Transform target;
    public float rotationSpeed = 5f; // Adjust rotation speed as needed

    public NavMeshAgent agent;
    public bool playerInSight = false;
    public Animator animator;
    public bool isWalking;
    public bool isRunning;
    public bool isStunned;

    [SerializeField] private float maxDistance;
    [SerializeField] private float peripheralVision;

    [SerializeField] private GameObject[] wanderSpots;
    [SerializeField] private float wanderRadius = 3f;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();

        // Ensure updateRotation is false so we can control it manually
        agent.updateRotation = false;

        target = wanderSpots[Random.Range(0, wanderSpots.Length - 1)].transform;
        agent.SetDestination(target.position);
        isWalking = true;

    }

    void Update()
    {
        if (isStunned)
        {
            agent.isStopped = true;
            target = wanderSpots[Random.Range(0, wanderSpots.Length - 1)].transform;
            agent.SetDestination(target.position);
        }
        else
        {
            findPlayer();
        }

        if (isWalking)
        {
            animator.SetBool("iswalking", isWalking);
        }

       if (isRunning)
        {
            animator.SetBool("isrunning", isRunning);

        }

        if (CanISeePlayer())
        {
            isRunning = true;
        }
        //set a condition to stop chasing player <<<<<<<<<
        playerInSight = CanISeePlayer();

        if(!playerInSight)
        {
            if(Vector3.Distance(this.transform.position, target.position) < wanderRadius)
            {
                target = wanderSpots[Random.Range(0, wanderSpots.Length - 1)].transform;
                agent.SetDestination(target.position);
                isWalking = true;
            }
        }


        if (agent != null && player != null && playerInSight)
        {
            target = player;
            // 1. Set the destination for the NavMeshAgent to handle pathfinding
            agent.SetDestination(target.position);
            isWalking = true;

            
        }

        FaceTarget();
    }

    public void Stun()
    {
        isStunned = true;
        animator.SetTrigger("lightstun");
        agent.isStopped = true;
    }

    public void findPlayer()
    {
        agent.isStopped = false;
        isStunned = false;
        isWalking = true;
        agent.SetDestination(target.position);
    }

    private bool CanISeePlayer()
    {
        Vector3 lookDirection = this.transform.forward.normalized;
        Vector3 toPlayerVector = player.transform.position - this.transform.position;
        float distanceToPlayer = toPlayerVector.magnitude;
        Vector3 directionToPlayer = toPlayerVector.normalized;

        if(distanceToPlayer > maxDistance)
        {
            return false;
        }
        float dotProduct = Vector3.Dot(directionToPlayer, lookDirection);
        //Debug.Log(dotProduct);
        if(dotProduct > peripheralVision)
        {
            agent.speed = 6;

            //Add a raycast, see if raycast hits player or wall. If player, return true, if wall, return false;
            return true;
        }

        return false;
    }

    private void FaceTarget()
    {
        // Get the next point on the path that the agent is steering towards
        Vector3 steeringTarget = agent.steeringTarget;

        // Calculate the direction to the steering target
        Vector3 direction = (steeringTarget - transform.position).normalized;

        // Only rotate if there's a valid direction and we are far enough from the target
        if (direction != Vector3.zero && agent.remainingDistance > agent.stoppingDistance)
        {
            // Create a rotation Quaternion looking in that direction (ignoring y-axis for 2D/top-down)
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            // Smoothly rotate the agent towards the new rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }

      void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player detected");
            playerInSight = true;
        }
    }


    public IEnumerator stuntimer()
    {
        Stun();
        yield return new WaitForSeconds(5f);
        findPlayer();

    }


}
