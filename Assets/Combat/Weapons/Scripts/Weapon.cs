using Characters.Enemies;
using Characters.Enemies.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        public float damage;
        public float range;
        protected IAttackCommand AttackCommand;

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
