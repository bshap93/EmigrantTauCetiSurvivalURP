using Characters.CharacterState;
using Characters.Enemies;
using Characters.Enemies.States;
using UnityEngine;

namespace Characters.NPCs.Enemies.States
{
    public class ChaseState : EnemyState
    {
        readonly Transform _target;
        public ChaseState(EnemyState formerState, Transform target) : base(formerState, target)
        {
            if (formerState is AttackState)
                Debug.Log("Resuming chase from attack.");

            _target = target;
        }

        public override void Enter(Enemy enemy)
        {
            SetChaseDestination(enemy);
        }

        public override void Update(Enemy enemy)
        {
            if (IsPlayerInAttackRange(enemy))
                TransitionToAttackState(enemy);
            else if (HasLostPlayer(enemy))
                TransitionToPatrolState(enemy);
            else
                SetChaseDestination(enemy);
        }

        public override void Exit(Enemy enemy)
        {
            // Any cleanup logic when exiting chase state
        }

        bool IsPlayerInAttackRange(Enemy enemy)
        {
            return enemy.IsPlayerInAttackRange();
        }

        void TransitionToAttackState(Enemy enemy)
        {
            enemy.ChangeState(new AttackState(this, _target));
        }

        bool HasLostPlayer(Enemy enemy)
        {
            return !enemy.CanSeePlayer() && !enemy.IsPlayerInChaseRange();
        }

        void TransitionToPatrolState(Enemy enemy)
        {
            enemy.ChangeState(new PatrollingState(this));
        }

        void SetChaseDestination(Enemy enemy)
        {
            enemy.SetEnemyDestination(enemy.GetPlayerPosition());
            Debug.Log("Chasing player to: " + enemy.GetPlayerPosition());
        }
    }
}
