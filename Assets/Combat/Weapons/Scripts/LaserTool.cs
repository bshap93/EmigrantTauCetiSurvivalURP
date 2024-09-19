using Characters.Enemies;
using Combat.Weapons.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public class LaserTool : Weapon
    {
        public float damage = 10f;
        public float range = 50f;
        public Transform firePoint;

        void Start()
        {
            attackCommand = new RangedAttackCommand(damage, range, firePoint);
        }

        public override void Attack(Enemy target)
        {
            attackCommand.Execute(target, damage);
        }
    }
}
