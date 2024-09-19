using Characters.Enemies;
using Combat.Weapons.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public class EnergeticRod : Weapon
    {
        public Transform attackPoint;

        void Start()
        {
            damage = 5f;
            range = 2f;
            AttackCommand = new MeleeAttackCommand(damage, range, attackPoint);
        }

        public override void Attack(Enemy target)
        {
            AttackCommand.Execute(target, damage);
        }
    }
}
