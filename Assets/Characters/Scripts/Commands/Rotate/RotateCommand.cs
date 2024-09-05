using Core.Command;
using UnityEngine;

namespace Characters.Scripts.Commands.Rotate
{
    public class RotateCommand : BaseCommand
    {
        readonly Vector3? _absoluteDirection;

        // Constructor for relative rotation
        // Constructor for absolute rotation
        public RotateCommand(float angle, Vector3 cameraForward)
        {
            var absoluteDirection = Quaternion.Euler(0, angle, 0) * cameraForward;
            _absoluteDirection = absoluteDirection;
        }

        public override void Execute(GameObject actor)
        {
            if (_absoluteDirection.HasValue)
            {
                // Absolute rotation: rotate to face a specific direction
                var targetRotation = Quaternion.LookRotation(_absoluteDirection.Value);
                actor.transform.rotation = targetRotation;
            }
        }
    }
}
