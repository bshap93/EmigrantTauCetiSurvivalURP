using Core.Command;
using UnityEngine;

namespace Characters.Player.Scripts.Commands
{
    public abstract class MoveCommand : BaseCommand
    {
        protected readonly Transform CameraTransform;

        protected MoveCommand(Transform cameraTransform)
        {
            CameraTransform = cameraTransform;
        }

        public override void Execute(GameObject actor)
        {
            Debug.Log("MoveCommand.Execute() called");
        }
    }

    public class MoveForwardCommand : MoveCommand
    {
        public MoveForwardCommand(Transform cameraTransform) : base(cameraTransform)
        {
        }

        public override void Execute(GameObject actor)
        {
            base.Execute(actor);
            // Move forward relative to the camera's facing direction
            var forward = CameraTransform.forward;
            forward.y = 0; // Ignore vertical movement
            actor.transform.Translate(forward.normalized);
        }
    }

    public class MoveBackwardCommand : MoveCommand
    {
        public MoveBackwardCommand(Transform cameraTransform) : base(cameraTransform)
        {
        }

        public override void Execute(GameObject actor)
        {
            // Move backward relative to the camera's facing direction
            var backward = -CameraTransform.forward;
            backward.y = 0; // Ignore vertical movement
            actor.transform.Translate(backward.normalized);
        }
    }

    public class MoveLeftCommand : MoveCommand
    {
        public MoveLeftCommand(Transform cameraTransform) : base(cameraTransform)
        {
        }

        public override void Execute(GameObject actor)
        {
            // Move left relative to the camera's facing direction
            var left = -CameraTransform.right;
            left.y = 0; // Ignore vertical movement
            actor.transform.Translate(left.normalized);
        }
    }

    public class MoveRightCommand : MoveCommand
    {
        public MoveRightCommand(Transform cameraTransform) : base(cameraTransform)
        {
        }

        public override void Execute(GameObject actor)
        {
            // Move right relative to the camera's facing direction
            var right = CameraTransform.right;
            right.y = 0; // Ignore vertical movement
            actor.transform.Translate(right.normalized);
        }
    }
}
