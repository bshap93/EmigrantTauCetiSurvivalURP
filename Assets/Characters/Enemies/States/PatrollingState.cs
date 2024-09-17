using Characters.CharacterState;
using Characters.Enemies;
using UnityEngine;

namespace Characters.NPCs.Enemies.States
{
    public class PatrollingState : EnemyState
    {
        readonly float _idleTime = 2f;
        int _currentWaypointIndex;
        float _idleTimer;

        bool _isIdle;
        public PatrollingState(EnemyState formerState) : base(formerState, null)
        {
        }


        public EnemyState FormerState { get; set; }
        public override void Enter(Enemy enemy)
        {
            if (enemy.waypoints.Count <= 0) enemy.FindWaypoints();
            enemy.SetDestination(enemy.waypoints[_currentWaypointIndex].position);
            _isIdle = false;
        }
        public override void Update(Enemy enemy)
        {
            if (!_isIdle)
            {
                if (enemy.HasReachedDestination() && enemy.waypoints.Count > 0)
                {
                    _isIdle = true;
                    _idleTimer = 0f;
                }
            }
            else
            {
                _idleTimer += Time.deltaTime;

                if (_idleTimer >= _idleTime)
                {
                    _currentWaypointIndex = (_currentWaypointIndex + 1) % enemy.waypoints.Count;
                    enemy.SetDestination(enemy.waypoints[_currentWaypointIndex].position);
                    _isIdle = false;
                }
            }


            if (enemy.CanSeePlayer()) enemy.ChangeState(new ChaseState(this, enemy.player));
        }

        public override void Exit(Enemy enemy)
        {
            // Nothing to do here
        }
    }
}
