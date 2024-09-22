using Characters.Enemies;
using Characters.Enemies.Attacks.Commands;
using Characters.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public abstract class Weapon : MonoBehaviour, IEquippableItem
    {
        public float damage;
        public float range;
        protected IAttackCommand AttackCommand;

        public void Equip(IDamageable equipper)
        {
            Debug.Log("Equipping weapon");
        }
        public void Unequip(IDamageable equipper)
        {
            Debug.Log("Unequipping weapon");
        }

        public abstract void Attack(Enemy target); // Implemented by subclasses

        public void SetAttackCommand(IAttackCommand attackCommand)
        {
            AttackCommand = attackCommand;
        }

        public IAttackCommand GetAttackCommand()
        {
            return AttackCommand;
        }

        public float GetDamage()
        {
            return damage;
        }
    }
}
