using System.Collections.Generic;
using Characters.CharacterState;
using Characters.CharacterState.States;
using Characters.NPCs.Scripts.Visiblity;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.NPCs.Enemies.Scripts
{
    /// <summary>
    ///     The Enemy class is responsible for managing the enemy's states
    ///     as well as movement
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;
        public List<Transform> waypoints;
        public Transform player;
        public float attackCooldown = 1.5f; // Cooldown duration in second

        [SerializeField] float detectionRange = 10f;
        [SerializeField] float attackRange = 2f;

        [SerializeField] float memoryDuration = 5f; // How long the enemy remembers the player after losing sight

        EnemyState _currentState;
        float _memoryTimer;
        EnemyVisiblity _visibility;

        // Start is called before the first frame update
        void Start()
        {
            // Get the EnemyVisiblity component
            _visibility = GetComponent<EnemyVisiblity>();
            // Set the initial state to patrolling, and former state to null
            _currentState = new PatrollingState(null);

            // Find the player object
            if (player == null)
                player = GameObject.FindWithTag("Player").transform;

            // Get the NavMeshAgent component
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

        /// <summary>
        ///     Set the destination for the enemy to move to on the NavMesh
        /// </summary>
        /// <param name="destination"></param>
        public void SetDestination(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
            Debug.Log("Set destination to " + destination);
        }
        /// <summary>
        ///     Check if the enemy has reached its destination on the NavMesh
        /// </summary>
        /// <returns></returns>
        public bool HasReachedDestination()
        {
            return !navMeshAgent.pathPending && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
        }
        /// <summary>
        ///     Change the enemy's state to a new state
        /// </summary>
        /// <param name="newState"></param>
        public void ChangeState(EnemyState newState)
        {
            if (_currentState != null)
                _currentState.Exit(this);

            _currentState = newState;
            _currentState.Enter(this);

            Debug.Log("Changed state to " + _currentState.GetType().Name);
        }
        /// <summary>
        ///     Call method from EnemyVisibility to check if the player is visible
        ///     or has seen the enemy in as much time as memoryTimer
        /// </summary>
        /// <returns></returns>
        public bool CanSeePlayer()
        {
            if (_visibility.TargetIsVisible)
            {
                _memoryTimer = Time.time + memoryDuration; // Reset memory timer when the player is visible
                return true;
            }

            // If memory timer is still running, keep chasing
            if (Time.time < _memoryTimer) return true; // The enemy is still chasing even if they lost sight

            return false;
        }

        /// <summary>
        ///     Without considering ability to see the player, check
        ///     if the player is within a certain range of the enemy
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        bool IsPlayerInRange(float range)
        {
            return Vector3.Distance(transform.position, player.position) < range;
        }

        // Call for specific ranges

        public bool IsPlayerInAttackRange()
        {
            return IsPlayerInRange(attackRange);
        }

        public bool IsPlayerInChaseRange()
        {
            return IsPlayerInRange(detectionRange);
        }

        // Control the enemy's movement in NavMesh 

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
