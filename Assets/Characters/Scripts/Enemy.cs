using System.Collections.Generic;
using Characters.CharacterState;
using Characters.CharacterState.States;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Scripts
{
    public class Enemy : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public List<Transform> waypoints;
        public Transform player;
        public LayerMask obstacleMask;
        public float detectionRange = 10f;
        IEnemyState _currentState;

        void Start()
        {
            _currentState = new PatrollingState();

            if (player == null)
                player = GameObject.FindWithTag("Player").transform;

            navMeshAgent = GetComponent<NavMeshAgent>();

            var waypointParent = GameObject.Find("Waypoints");

            if (waypointParent != null)
                foreach (Transform child in waypointParent.transform)
                    waypoints.Add(child);
        }

        void Update()
        {
            _currentState.Update(this);
        }
        public void SetDestination(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
            Debug.Log("Set destination to " + destination);
        }
        public bool HasReachedDestination()
        {
            return !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
        }
        public void ChangeState(IEnemyState newState)
        {
            if (_currentState != null)
                _currentState.Exit(this);

            _currentState = newState;
            _currentState.Enter(this);

            Debug.Log("Changed state to " + _currentState.GetType().Name);
        }
        // Method to check if the enemy can see the player
        public bool CanSeePlayer()
        {
            // Calculate distance to player
            var distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // If the player is within detection range
            if (distanceToPlayer <= detectionRange)
            {
                // Cast a ray from the enemy to the player
                RaycastHit hit;
                var directionToPlayer = (player.position - transform.position).normalized;

                if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
                    // Check if the ray hits the player
                    if (hit.transform == player)
                        return true; // The enemy can see the player
            }

            // Enemy cannot see the player
            return false;
        }
        public bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, player.position) < 2;
        }
        public void StopMoving()
        {
            navMeshAgent.isStopped = true;
        }
        public void StartMoving()
        {
            navMeshAgent.isStopped = false;
        }
        public void PerformAttack()
        {
            Debug.Log("Attacking player");
        }
        public Vector3 GetPlayerPosition()
        {
            return player.position;
        }
    }
}
