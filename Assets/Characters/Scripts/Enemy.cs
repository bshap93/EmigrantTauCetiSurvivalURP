using System.Collections.Generic;
using Characters.CharacterState;
using Characters.CharacterState.States;
using Characters.NPCs.Scripts.Visiblity;
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
        public float attackRange = 2f;
        public float timeNeededToLosePlayer = 5f;
        public float attackCooldown = 1.5f; // Cooldown duration in seconds

        public float memoryDuration = 5f; // How long the enemy remembers the player after losing sight

        EnemyState _currentState;
        NpcVisibility _visibility;
        float memoryTimer;

        void Start()
        {
            _visibility = GetComponent<NpcVisibility>();
            _currentState = new PatrollingState(null);

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
        public void ChangeState(EnemyState newState)
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
            if (_visibility.TargetIsVisible)
            {
                memoryTimer = Time.time + memoryDuration; // Reset memory timer when the player is visible
                return true;
            }

            // If memory timer is still running, keep chasing
            if (Time.time < memoryTimer) return true; // The enemy is still chasing even if they lost sight

            return false;
        }
        bool IsPlayerInRange(float range)
        {
            return Vector3.Distance(transform.position, player.position) < range;
        }

        public bool IsPlayerInAttackRange()
        {
            return IsPlayerInRange(attackRange);
        }

        public bool IsPlayerInChaseRange()
        {
            return IsPlayerInRange(detectionRange);
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
