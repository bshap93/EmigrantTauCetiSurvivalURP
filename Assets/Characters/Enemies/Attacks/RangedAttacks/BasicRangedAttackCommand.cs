using Characters.Enemies.Attacks.Commands;
using Characters.Scripts;

namespace Characters.Enemies.Attacks.RangedAttacks
{
    public class BasicRangedAttackCommand : IAttackCommand
    {
        public void Execute(IDamageable target, float damage)
        {
            target.TakeDamage(target, damage);
        }
    }
}
