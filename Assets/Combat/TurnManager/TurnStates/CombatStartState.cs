using Characters.Enemies;
using Characters.Player.Scripts.States;
using UnityEngine;

namespace Combat.TurnManager.TurnStates
{
    public class CombatStartState : TurnState
    {
        public override void EnterState(TurnManager turnManager)
        {
            Debug.Log("Combat Started!");
            // Initialize combat setup, like positioning or any special rules
            if (turnManager.GetCurrentAggressor() is Enemy) // If the aggressor is an enemy
                turnManager.ChangeState(new EnemyTurnState(turnManager.enemies)); // Start with the enemy's turn
            else
                turnManager.ChangeState(new PlayerTurnState()); // Start with the player's turn
        }

        public override void UpdateState(TurnManager turnManager)
        {
        }

        public override void ExitState(TurnManager turnManager)
        {
            Debug.Log("Exiting Combat Start State.");
        }
    }
}
