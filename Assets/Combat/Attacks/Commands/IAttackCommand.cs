using Characters.Enemies;
using JetBrains.Annotations;

namespace Combat.Weapons.Attacks.Commands
{
    public interface IAttackCommand
    {
        void Execute([CanBeNull] Enemy target);
    }
}
