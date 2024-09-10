using UnityEngine;
using UnityEngine.AI;

public class PlaceholderNavAgent : MonoBehaviour
{
    public Transform target; // Assign this in the inspector to test movement to a specific point
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // If no target is assigned, move to a random point
        if (target != null)
            agent.SetDestination(target.position);
        else
            SetRandomDestination();
    }

    void Update()
    {
        // If the agent reaches its destination, set a new random one
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance) SetRandomDestination();
    }

    void SetRandomDestination()
    {
        // Define a random point within a certain radius
        var randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, 1)) agent.SetDestination(hit.position);
    }
}
