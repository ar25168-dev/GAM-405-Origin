using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    public Transform target; // Drag your target GameObject here in the Inspector
    public float rotationSpeed = 5f; // Adjust rotation speed as needed

    public NavMeshAgent agent;
    public bool playerInSight = false;

    [SerializeField] private float maxDistance;
    [SerializeField] private float peripheralVision;

    [SerializeField] private GameObject[] wanderSpots;

    void Start()
    {
        
        agent = this.GetComponent<NavMeshAgent>();

        // Ensure updateRotation is false so we can control it manually
        agent.updateRotation = false;

    }

    void Update()
    {
       
        //set a condition to stop chasing player <<<<<<<<<
        playerInSight = CanISeePlayer();

        //If I can't see player, navigate to some pretermined spots


        if (agent != null && target != null && playerInSight)
        {
            // 1. Set the destination for the NavMeshAgent to handle pathfinding
            agent.SetDestination(target.position);

            // 2. Handle the agent's rotation manually
            FaceTarget();
        }
    }

    private bool CanISeePlayer()
    {
        Vector3 lookDirection = this.transform.forward.normalized;
        Vector3 toPlayerVector = target.transform.position - this.transform.position;
        float distanceToPlayer = toPlayerVector.magnitude;
        Vector3 directionToPlayer = toPlayerVector.normalized;

        if(distanceToPlayer > maxDistance)
        {
            return false;
        }

        float dotProduct = Vector3.Dot(directionToPlayer, lookDirection);
        Debug.Log(dotProduct);
        if(dotProduct > peripheralVision)
        {
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


}
