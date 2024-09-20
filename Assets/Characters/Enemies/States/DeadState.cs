using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Characters.Enemies.States
{
    public class DeadState : EnemyState
    {
        public DeadState(Animator animator, [CanBeNull] EnemyState formerState) : base(
            formerState, null)
        {
        }
        public override void Enter(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            Debug.Log("Enemy is dead");
        }
        public override void Update(Enemy enemy)
        {
            throw new NotImplementedException();
        }
        public override void Exit(Enemy enemy)
        {
            throw new NotImplementedException();
        }
    }
}
