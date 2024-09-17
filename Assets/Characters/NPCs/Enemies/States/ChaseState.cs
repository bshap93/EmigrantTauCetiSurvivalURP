using Characters.CharacterState;
using Characters.CharacterState.States;
using Characters.NPCs.Enemies.Scripts;
using UnityEngine;

namespace Characters.NPCs.Enemies.States
{
    public class ChaseState : EnemyState
    {
        public ChaseState(EnemyState formerState) : base(formerState)
        {
            if (formerState is AttackState)
                Debug.Log("Resuming chase from attack.");
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
            enemy.ChangeState(new AttackState(this));
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
            enemy.SetDestination(enemy.GetPlayerPosition());
            Debug.Log("Chasing player to: " + enemy.GetPlayerPosition());
        }
    }
}
