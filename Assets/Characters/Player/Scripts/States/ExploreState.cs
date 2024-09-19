using JetBrains.Annotations;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class ExploreState : PlayerState
    {
        public ExploreState([CanBeNull] PlayerState formerState, [CanBeNull] Transform target) : base(
            formerState, target)
        {
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
