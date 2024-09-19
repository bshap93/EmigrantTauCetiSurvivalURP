using JetBrains.Annotations;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class CombatReadyState : PlayerState
    {
        public CombatReadyState([CanBeNull] Transform target) : base(
            target)
        {
            // Player is now ready for combat
            Debug.Log("Player is combat ready.");
        }
        public override void Enter(PlayerCharacter playerCharacter)
        {
        }
        public override void Update(PlayerCharacter playerCharacter)
        {
        }
        public override void Exit(PlayerCharacter playerCharacter)
        {
        }
    }
}
