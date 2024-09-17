using Characters.Scripts;
using UnityEngine;

namespace Characters.CharacterState.States
{
    public class ChaseState : EnemyState
    {
        public ChaseState(EnemyState formerState) : base(formerState)
        {
            if (formerState is AttackState) Debug.Log("Resuming chase");
        }

        public override void Enter(Enemy enemy)
        {
            enemy.SetDestination(enemy.player.position);
        }
        public override void Update(Enemy enemy)
        {
            // If the player is in attack range, switch to AttackState
            if (enemy.IsPlayerInAttackRange())
            {
                enemy.ChangeState(new AttackState(this));
                return;
            }

            // If the player can't be seen and isn't within chase range, return to patrol
            if (!enemy.CanSeePlayer() && !enemy.IsPlayerInChaseRange())
            {
                enemy.ChangeState(new PatrollingState(this));
                return;
            }

            // Continue chasing the player
            enemy.SetDestination(enemy.GetPlayerPosition());
        }


        public override void Exit(Enemy enemy)
        {
            // Nothing to do here
        }
    }
}
