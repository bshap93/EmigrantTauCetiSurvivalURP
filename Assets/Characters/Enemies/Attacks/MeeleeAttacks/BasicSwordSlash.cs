using System.Collections.Generic;
using Characters.Enemies.Attacks.Commands;
using Characters.Scripts;
using DG.Tweening;
using UnityEngine;

namespace Characters.Enemies.Attacks.MeeleeAttacks
{
    public class SimpleSlashAttack : IAttackCommand
    {
        static readonly int SwordSlash = Animator.StringToHash("SwordSlash");
        readonly int _damage;
        readonly DOTweenAnimation _dotweenAnimation;
        public SimpleSlashAttack(int damage, DOTweenAnimation swordSlash)
        {
            _damage = damage;
            _dotweenAnimation = swordSlash;
        }
        public void Execute(IDamageable target, float dmgValue)
        {
            _dotweenAnimation.DORestart();
            _dotweenAnimation.DOPlay();
            target.TakeDamage(target, dmgValue);
        }

        IEnumerator<WaitForSeconds>
            ApplyDamageAfterDelay(IDamageable target, float delay)
        {
            yield return new WaitForSeconds(delay); // Wait for the specified delay
            target.TakeDamage(target, _damage); // Apply the damage
            Debug.Log("Melee attack: dealt " + _damage + " damage after delay");
        }
    }
}
