using Characters.Player.Scripts.States;
using UnityEngine;

namespace Combat.TurnManager.TurnStates
{
    public class PlayerTurnState : TurnState
    {
        public override void EnterState(TurnManager turnManager)
        {
            Debug.Log("Player's Turn!");
            turnManager.player.StartTurn();
        }

        public override void UpdateState(TurnManager turnManager)
        {
            // Wait for the player to complete their action
            if (turnManager.player.HasCompletedAction())
                turnManager.ChangeState(new EnemyTurnState(turnManager.enemies)); // Move to enemy turn when done
        }

        public override void ExitState(TurnManager turnManager)
        {
            Debug.Log("Exiting Player Turn State.");
        }
    }
}
