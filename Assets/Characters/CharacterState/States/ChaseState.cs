using Characters.Scripts;

namespace Characters.CharacterState.States
{
    public class ChaseState : IEnemyState
    {
        public void Enter(Enemy enemy)
        {
            enemy.SetDestination(enemy.player.position);
        }
        public void Update(Enemy enemy)
        {
            enemy.SetDestination(enemy.player.position);

            if (enemy.IsPlayerInRange())
                enemy.ChangeState(new AttackState());

            if (!enemy.CanSeePlayer()) enemy.ChangeState(new PatrollingState());
        }

        public void Exit(Enemy enemy)
        {
            // Nothing to do here
        }
    }
}
