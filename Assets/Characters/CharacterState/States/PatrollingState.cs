using Characters.Scripts;
using UnityEngine;

namespace Characters.CharacterState.States
{
    public class PatrollingState : IEnemyState
    {
        int _currentWaypointIndex;
        int currentWaypointIndex = 0;
        readonly float idleTime = 2f;
        float idleTimer;

        bool isIdle;


        public void Enter(Enemy enemy)
        {
            enemy.SetDestination(enemy.waypoints[_currentWaypointIndex].position);
            isIdle = false;
        }
        public void Update(Enemy enemy)
        {
            if (!isIdle)
            {
                if (enemy.HasReachedDestination() && enemy.waypoints.Count > 0)
                {
                    isIdle = true;
                    idleTimer = 0f;
                }
            }
            else
            {
                idleTimer += Time.deltaTime;

                if (idleTimer >= idleTime)
                {
                    _currentWaypointIndex = (_currentWaypointIndex + 1) % enemy.waypoints.Count;
                    enemy.SetDestination(enemy.waypoints[_currentWaypointIndex].position);
                    isIdle = false;
                }
            }


            if (enemy.CanSeePlayer())
                enemy.ChangeState(new ChaseState());
        }

        public void Exit(Enemy enemy)
        {
            // Nothing to do here
        }
    }
}
