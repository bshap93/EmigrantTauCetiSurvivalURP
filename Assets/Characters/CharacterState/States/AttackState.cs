using Characters.Scripts;
using UnityEngine;

namespace Characters.CharacterState.States
{
    public class AttackState : EnemyState
    {
        float _nextAttackTime; // Tracks when the enemy can attack next
        public AttackState(EnemyState formerState) : base(formerState)
        {
        }


        public EnemyState FormerState { get; set; }
        public override void Enter(Enemy enemy)
        {
            enemy.StopMoving();
            _nextAttackTime = Time.time;
        }

        public override void Update(Enemy enemy)
        {
            // Check if enough time has passed since the last attack
            if (Time.time >= _nextAttackTime)
            {
                enemy.PerformAttack();

                // Set the next attack time based on the cooldown
                _nextAttackTime = Time.time + enemy.attackCooldown;
            }

            // Transition to chase state if player is out of range
            if (!enemy.IsPlayerInAttackRange())
                enemy.ChangeState(new ChaseState(this));
        }

        public override void Exit(Enemy enemy)
        {
            enemy.StartMoving();
        }
    }
}
