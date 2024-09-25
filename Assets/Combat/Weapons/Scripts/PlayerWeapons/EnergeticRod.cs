﻿using Characters.Scripts;
using Combat.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts.PlayerWeapons
{
    public class EnergeticRod : Weapon
    {
        public Transform attackPoint;


        public override void InitializeAttackCommand(WeaponHandler weaponHandler)
        {
            damage = 5f;
            range = 2f;
            AttackCommand = new MeleeAttackCommand(damage, range, attackPoint);
        }
        public override void Attack(IDamageable target, WeaponHandler handler)
        {
            AttackCommand.Execute(target, damage);
        }
    }
}
