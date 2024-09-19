using Characters.Enemies;
using Combat.Weapons.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public class EnergeticRod : Weapon
    {
        public float damage = 5f;
        public float range = 2f;
        public Transform attackPoint;

        void Start()
        {
            attackCommand = new MeleeAttackCommand(damage, range, attackPoint);
        }

        public override void Attack(Enemy target)
        {
            attackCommand.Execute(target, damage);
        }
    }
}
