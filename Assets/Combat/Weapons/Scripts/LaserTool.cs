using Characters.Enemies;
using Combat.Attacks.Commands;
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
            AttackCommand = new RangedAttackCommand(this, range, firePoint);
        }

        public override void Attack(Enemy target)
        {
            Debug.Log("LaserTool: Attack");
        }
    }
}
