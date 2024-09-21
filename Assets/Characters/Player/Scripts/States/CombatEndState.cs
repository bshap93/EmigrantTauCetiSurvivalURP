using Combat.TurnManager;
using Combat.TurnManager.TurnStates;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class CombatEndState : TurnState
    {
        public override void EnterState(TurnManager turnManager)
        {
            Debug.Log("Combat Ended!");
            // Cleanup or transition to the next phase of the game
        }

        public override void UpdateState(TurnManager turnManager)
        {
        }

        public override void ExitState(TurnManager turnManager)
        {
            Debug.Log("Exiting Combat End State.");
        }
    }
}
