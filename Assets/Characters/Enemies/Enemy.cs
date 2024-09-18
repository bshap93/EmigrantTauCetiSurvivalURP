using System.Collections.Generic;
using Characters.CharacterState;
using Characters.Enemies.Attacks.Commands;
using Characters.Enemies.Scripts;
using Characters.Enemies.States;
using Characters.Health.Scripts;
using Characters.Health.Scripts.Commands;
using Characters.Player.Scripts;
using Characters.Scripts;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Enemies
{
    /// <summary>
    ///     The Enemy class is responsible for managing the enemy's states
    ///     as well as movement
    /// </summary>
    public class Enemy : MonoBehaviour, IDamageable
    {
        static int _enemyCount;
        public NavMeshAgent navMeshAgent;
        public List<Transform> waypoints;
        public Transform player;

        public float attackCooldown = 1.5f; // Cooldown duration in second


        [SerializeField] float detectionRange = 10f;
        [SerializeField] float attackRange = 2f;

        [SerializeField] float memoryDuration = 5f; // How long the enemy remembers the player after losing sight

        public GameObject weapon;
        public double chaseDuration;
        readonly List<DOTweenAnimation> _animations = new();
        readonly List<IAttackCommand> _attacks = new();

        EnemyState _currentState;
        EnemyAttack _enemyAttack;
        string _enemyName;
        HealthSystem _healthSystem;
        float _memoryTimer;
        EnemyNavigation _navigation;
        EnemyVisiblity _visibility;

        // Start is called before the first frame update
        void Start()
        {
            _enemyCount++;
            _enemyName = "Enemy" + _enemyCount;

            _navigation = GetComponent<EnemyNavigation>();
            _enemyAttack = GetComponent<EnemyAttack>();


            _healthSystem = new HealthSystem(_enemyName, 100);
            // Get the EnemyVisiblity component
            _visibility = GetComponent<EnemyVisiblity>();
            // Set the initial state to patrolling, and former state to null
            if (_enemyCount % 2 == 0)
            {
                _currentState = new PatrollingState(null, true);
                Debug.Log("Enemy is going one way");
            }
            else
            {
                _currentState = new PatrollingState(null, false);
                Debug.Log("Enemy is going the other way");
            }


            ChangeState(_currentState);

            // Find the player object
            if (player == null)
                player = GameObject.FindWithTag("Player").transform;

            // Get the NavMeshAgent component
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            _currentState.Update(this);
        }
        public void TakeDamage(IDamageable dmgeable, float damage)
        {
            if (dmgeable is Enemy)
            {
                var dealDamageCommand = new DealDamageCommand();
                dealDamageCommand.Execute(_healthSystem, damage);
            }
        }
        public void FindWaypoints()
        {
            var waypointParent = GameObject.Find("Waypoints");

            if (waypointParent != null)
            {
                foreach (Transform child in waypointParent.transform)
                    waypoints.Add(child);

                Debug.Log("Enemy Found " + waypoints.Count + " waypoints");
            }
        }


        public void SetEnemyDestination(Vector3 destination)
        {
            _navigation.SetDestination(destination);
        }

        public bool HasEnemyReachedDestination()
        {
            return _navigation.HasReachedDestination();
        }

        public void ChangeState(EnemyState newState)
        {
            if (_currentState != null)
                _currentState.Exit(this);

            _currentState = newState;
            _currentState.Enter(this);

            Debug.Log("Changed state to " + _currentState.GetType().Name);
        }

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
            _navigation.StopMoving();
        }
        public void StartMoving()
        {
            _navigation.StartMoving();
        }


        public void PerformAttack(IAttackCommand attackCommand)
        {
            _enemyAttack.PerformAttack(
                player.gameObject.GetComponent<PlayerStateController>());
        }
        public Vector3 GetPlayerPosition()
        {
            return player.position;
        }
        public IAttackCommand GetAttack()
        {
            return _enemyAttack.GetAttack();
        }
    }
}
