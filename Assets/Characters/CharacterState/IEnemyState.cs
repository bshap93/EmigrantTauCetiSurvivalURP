using Characters.NPCs.Enemies.Scripts;
<<<<<<< Updated upstream
using Characters.Scripts;
=======
>>>>>>> Stashed changes
using JetBrains.Annotations;

namespace Characters.CharacterState
{
    public abstract class EnemyState
    {
        [CanBeNull] EnemyState _formerState;
        protected EnemyState([CanBeNull] EnemyState formerState)
        {
            _formerState = formerState;
        }
        public abstract void Enter(Enemy enemy);
        public abstract void Update(Enemy enemy);
        public abstract void Exit(Enemy enemy);
    }
}
