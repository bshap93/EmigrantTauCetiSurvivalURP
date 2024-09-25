using System;
using Characters.Enemies.Attacks.Commands;
using Characters.Scripts;
using Items.Equipment;
using Items.Scripts;

namespace Combat.Weapons.Scripts
{
    public abstract class Weapon : EquippableItemObject
    {
        public IAttackCommand AttackCommand;

        public abstract void InitializeAttackCommand(WeaponHandler weaponHandler);


        public virtual void Attack(IDamageable target, WeaponHandler weaponHandler)
        {
            throw new NotImplementedException();
        }

        public IAttackCommand GetAttackCommand()
        {
            return AttackCommand;
        }

        public void SetAttackCommand(IAttackCommand command)
        {
            AttackCommand = command;
        }

        public override void InitializeUseCommand(EquippableHandler equippableHandler)
        {
            if (equippableHandler is WeaponHandler handler)
                InitializeAttackCommand(handler);
        }
    }
}
