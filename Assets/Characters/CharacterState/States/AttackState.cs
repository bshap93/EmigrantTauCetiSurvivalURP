using Characters.Scripts;
using UnityEngine;

namespace Characters.CharacterState.States
{
    public class AttackState : IEnemyState
    {
        readonly float attackCooldown = 1.5f; // Cooldown duration in seconds
        float nextAttackTime; // Tracks when the enemy can attack next

        public void Enter(Enemy enemy)
        {
            enemy.StopMoving();
        }

        public void Update(Enemy enemy)
        {
            // Check if enough time has passed since the last attack
            if (Time.time >= nextAttackTime)
            {
                enemy.PerformAttack();

                // Set the next attack time based on the cooldown
                nextAttackTime = Time.time + attackCooldown;
            }

            // Transition to chase state if player is out of range
            if (!enemy.IsPlayerInRange())
                enemy.ChangeState(new ChaseState());

            // Transition to patrolling if the player is no longer visible
            if (!enemy.CanSeePlayer())
                enemy.ChangeState(new PatrollingState());
        }

        public void Exit(Enemy enemy)
        {
            enemy.StartMoving();
        }
    }
}
