using Characters.Enemies;
using Combat.Weapons.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public class LaserTool : Weapon
    {
        public Transform firePoint;

        void Start()
        {
            damage = 10f;
            range = 50f;
            AttackCommand = new RangedAttackCommand(damage, range, firePoint);
        }

        public override void Attack(Enemy target)
        {
            AttackCommand.Execute(target, damage);
            Debug.Log("LaserTool: Attack");
        }
    }
}
