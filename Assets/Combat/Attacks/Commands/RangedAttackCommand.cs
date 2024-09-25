using Characters.Enemies.Attacks.Commands;
using Characters.Scripts;
using Combat.Weapons;
using Combat.Weapons.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Combat.Attacks.Commands
{
    public class RangedAttackCommand : IAttackCommand
    {
        readonly float _damage;
        readonly EquippableItemObject _equippableItemObject;
        readonly WeaponHandler _weaponHandler;
        Transform _firePoint;
        float _range;

        public RangedAttackCommand(EquippableItemObject equippableItemObject, float range, WeaponHandler weaponHandler)
        {
            _range = range;
            _weaponHandler = weaponHandler;
            _firePoint = weaponHandler.firePoint;
            _equippableItemObject = equippableItemObject;
            _damage = equippableItemObject.GetDamage();
        }

        public void Execute(IDamageable target, float dmgValue)
        {
            if (target == null && _equippableItemObject is Weapon weapon)
                weapon.Attack(null, _weaponHandler);
        }
        public float GetDamage()
        {
            return _damage;
        }
    }
}
