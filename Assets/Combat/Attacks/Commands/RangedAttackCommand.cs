using Characters.Enemies.Attacks.Commands;
using Characters.Scripts;
using Combat.Weapons.Scripts;
using UnityEngine;

namespace Combat.Attacks.Commands
{
    public class RangedAttackCommand : IAttackCommand
    {
        readonly Weapon _weapon;
        readonly float _damage;
        Transform _firePoint;
        float _range;

        public RangedAttackCommand(Weapon weapon, float range, Transform firePoint)
        {
            _range = range;
            _firePoint = firePoint;
            _weapon = weapon;
            _damage = weapon.GetDamage();
        }

        public void Execute(IDamageable target, float dmgValue)
        {
            if (target == null) _weapon.Attack(null);
        }
        public float GetDamage()
        {
            return _damage;
        }
    }
}
