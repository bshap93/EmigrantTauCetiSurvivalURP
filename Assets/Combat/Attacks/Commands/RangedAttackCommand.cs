using Characters.Scripts;
using UnityEngine;

namespace Combat.Weapons.Attacks.Commands
{
    public class RangedAttackCommand : Characters.Enemies.Attacks.Commands.IAttackCommand
    {
        float _damage;
        Transform _firePoint;
        float _range;

        public RangedAttackCommand(float damage, float range, Transform firePoint)
        {
            _damage = damage;
            _range = range;
            _firePoint = firePoint;
        }

        public void Execute(IDamageable target, float dmgValue)
        {
        }
    }
}
