using Characters.Scripts;

namespace Characters.Enemies.Attacks.Commands
{
    public interface IAttackCommand
    {
        void Execute(IDamageable target, float damage);
    }
}
