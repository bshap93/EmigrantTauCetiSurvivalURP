using JetBrains.Annotations;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class CombatReadyState : PlayerState
    {
        public CombatReadyState([CanBeNull] PlayerState formerState, [CanBeNull] Transform target) : base(
            formerState, target)
        {
            // Player is now ready for combat
            Debug.Log("Player is combat ready.");
        }
        public override void Enter(PlayerCharacter playerCharacter)
        {
            // Handle combat input in this state
            if (Input.GetMouseButton(0))
                // Transition to AttackingState
                playerCharacter.ChangeState(new AttackingState(this, Target));
            // You can also handle state reversion here (e.g., back to exploration)
        }
        public override void Update(PlayerCharacter playerCharacter)
        {
        }
        public override void Exit(PlayerCharacter playerCharacter)
        {
        }
    }
}
