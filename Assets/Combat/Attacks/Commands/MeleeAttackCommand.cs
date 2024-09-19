using Characters.Scripts;
using UnityEngine;

namespace Combat.Weapons.Attacks.Commands
{
    public class MeleeAttackCommand : Characters.Enemies.Attacks.Commands.IAttackCommand
    {
        Transform _attackPoint;
        float _damage;
        float _range;

        public MeleeAttackCommand(float damage, float range, Transform attackPoint)
        {
            _damage = damage;
            _range = range;
            _attackPoint = attackPoint;
        }


        public void Execute(IDamageable target, float dmgValue)
        {
        }
    }
}
