using Characters.Enemies.Attacks.Commands;
using Characters.Scripts;
using Items.Scripts;
using JetBrains.Annotations;
using Polyperfect.Crafting.Integration;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public abstract class Weapon : BaseItemObject, IEquippableItem
    {
        public float damage;
        public float range;
        protected IAttackCommand AttackCommand;

        public void Equip(IEquippableItem item, IDamageable equipper)
        {
            Debug.Log($"Equipped weapon: {name}");
        }
        public void Unequip(IEquippableItem item, IDamageable equipper)
        {
            Debug.Log($"Unequipped weapon: {name}");
        }


        protected abstract void InitializeAttackCommand(WeaponHandler weaponHandler);

        public abstract void
            Attack([CanBeNull] IDamageable target, WeaponHandler weaponHandler); // Implemented by subclasses

        public IAttackCommand GetAttackCommand()
        {
            return AttackCommand;
        }

        public void SetAttackCommand(IAttackCommand command)
        {
            AttackCommand = command;
        }

        public float GetDamage()
        {
            return damage;
        }
    }
}
