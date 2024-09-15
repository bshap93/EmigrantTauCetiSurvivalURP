using Characters.Scripts;

namespace Characters.CharacterState.States
{
    public class AttackState : IEnemyState
    {
        public void Enter(Enemy enemy)
        {
            enemy.StopMoving();
        }

        public void Update(Enemy enemy)
        {
            enemy.PerformAttack();

            if (!enemy.IsPlayerInRange())
                enemy.ChangeState(new ChaseState());
        }

        public void Exit(Enemy enemy)
        {
            // Nothing to do here
        }
    }
}
