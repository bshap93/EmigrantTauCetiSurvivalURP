using JetBrains.Annotations;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class AttackingState : PlayerState
    {
        public AttackingState([CanBeNull] PlayerState formerState, [CanBeNull] Transform target)
            : base(formerState, target)
        {
        }

        public override void Enter(PlayerCharacter playerCharacter)
        {
            // Begin attack sequence
            Debug.Log("Player is attacking.");

            // Execute the attack command (could be melee or ranged)
            var attackCommand = playerCharacter.GetAttackCommand();
            attackCommand.Execute(
                null,
                playerCharacter.GetCurrentWeapon().GetDamage());

            // After attacking, transition back to CombatReadyState or ExplorationState
            playerCharacter.ChangeState(new CombatReadyState(this, Target));
        }

        public override void Update(PlayerCharacter playerCharacter)
        {
            // Attacking typically doesn't need to handle updates unless you have complex animations
        }

        public override void Exit(PlayerCharacter playerCharacter)
        {
            // Clean up any attack state-specific logic
        }
    }
}
