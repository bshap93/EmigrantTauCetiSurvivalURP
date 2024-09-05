using Core.Command;
using UnityEngine;

namespace Characters.Scripts.Commands.Rotate
{
    public class RotateCommand : BaseCommand
    {
        readonly Vector3? _absoluteDirection;
        readonly float? _relativeAngle;

        // Constructor for relative rotation
        public RotateCommand(float relativeAngle)
        {
            _relativeAngle = relativeAngle;
            _absoluteDirection = null;
        }

        // Constructor for absolute rotation
        public RotateCommand(Vector3 absoluteDirection)
        {
            _absoluteDirection = absoluteDirection;
            _relativeAngle = null;
        }

        public override void Execute(GameObject actor)
        {
            if (_relativeAngle.HasValue)
            {
                // Relative rotation: rotate by a certain angle
                actor.transform.Rotate(0, _relativeAngle.Value, 0);
            }
            else if (_absoluteDirection.HasValue)
            {
                // Absolute rotation: rotate to face a specific direction
                var targetRotation = Quaternion.LookRotation(_absoluteDirection.Value);
                actor.transform.rotation = Quaternion.Slerp(
                    actor.transform.rotation, targetRotation, Time.deltaTime * 10f); // Adjust speed as necessary
            }
        }
    }
}
