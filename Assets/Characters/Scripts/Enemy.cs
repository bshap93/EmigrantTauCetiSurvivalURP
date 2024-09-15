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
        }
        public bool CanSeePlayer()
        {
            return Vector3.Distance(transform.position, player.position) < 10;
        }
        public bool IsPlayerInRange()
        {
            return Vector3.Distance(transform.position, player.position) < 2;
        }
        public void StopMoving()
        {
            navMeshAgent.isStopped = true;
        }
        public void PerformAttack()
        {
            Debug.Log("Attacking player");
        }
    }
}
