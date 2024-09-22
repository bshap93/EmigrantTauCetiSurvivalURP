using JetBrains.Annotations;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class CombatReadyState : PlayerState
    {
        static readonly int CombatStance = Animator.StringToHash("CombatStance");
        readonly Animator _animator;
        PlayerCharacter _playerCharacter;
        public CombatReadyState([CanBeNull] Transform target, Animator animator) : base(
            target)
        {
            _animator = animator;
        }
        public override void Enter(PlayerCharacter playerCharacter)
        {
            // Player is now ready for combat
            _animator.SetBool(CombatStance, true);
            
        }
        public override void Update(PlayerCharacter playerCharacter)
        {
        }
        public override void Exit(PlayerCharacter playerCharacter)
        {
            _animator.SetBool(CombatStance, false);
        }
    }
}
