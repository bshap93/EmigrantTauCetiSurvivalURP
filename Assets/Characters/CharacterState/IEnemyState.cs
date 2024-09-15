using Characters.Scripts;

namespace Characters.CharacterState
{
    public interface IEnemyState
    {
        public void Enter(Enemy enemy);

        public void Update(Enemy enemy);

        public void Exit(Enemy enemy);
    }
}
