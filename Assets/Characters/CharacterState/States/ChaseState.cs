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
            // enemy.SetDestination(enemy.player.position);

            if (enemy.IsPlayerInAttackRange())
                enemy.ChangeState(new AttackState(this));

            if (!enemy.CanSeePlayer() && !enemy.IsPlayerInChaseRange())
                enemy.ChangeState(new PatrollingState(this));
        }

        public override void Exit(Enemy enemy)
        {
            // Nothing to do here
        }
    }
}
