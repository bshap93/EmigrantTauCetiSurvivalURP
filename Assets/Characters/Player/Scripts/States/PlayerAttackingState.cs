using Combat.Weapons.Scripts;
using JetBrains.Annotations;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class PlayerAttackingState : PlayerState
    {
        static readonly int CombatStance = Animator.StringToHash("RangedCombatStance");
        readonly Animator _animator;
        public PlayerAttackingState([CanBeNull] Transform target, Animator animator)
            : base(target)
        {
            _animator = animator;
        }

        public override void Enter(PlayerCharacter playerCharacter)
        {
            _animator.SetBool(CombatStance, true);


            // Execute the attack command (could be melee or ranged)
            var attackCommand = playerCharacter.GetAttackCommand();
            if (playerCharacter.GetEquippedItem() is Weapon weapon)
                attackCommand.Execute(
                    null,
                    weapon.GetDamage());
            else // No weapon equipped
                Debug.LogError("No weapon equipped");
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
