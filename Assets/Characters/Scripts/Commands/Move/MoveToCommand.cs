using Core.Command;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.Scripts.Commands.Move
{
    public class MoveToCommand : BaseCommand
    {
        readonly Vector3 _destination;
        readonly NavMeshPath _path;
        readonly float _speed;
        readonly CharacterController _characterController;
        int _pathIndex;

        // Constructor for the move command
        public MoveToCommand(Vector3 destination, float speed, CharacterController characterController)
        {
            _destination = destination;
            _speed = speed;
            _path = new NavMeshPath();
            _characterController = characterController;
        }

        public override void Execute(GameObject actor)
        {
            // Get the CharacterController from the actor

            if (_characterController == null)
            {
                UnityEngine.Debug.LogError("No CharacterController found on the actor.");
                return;
            }

            // Calculate the NavMesh path to the destination
            NavMesh.CalculatePath(actor.transform.position, _destination, NavMesh.AllAreas, _path);

            if (_path.status == NavMeshPathStatus.PathComplete)
            {
                _pathIndex = 0; // Reset path index to the start of the path
                MoveAlongPath(actor, _characterController);
            }
            else
            {
                UnityEngine.Debug.LogWarning("Path could not be calculated.");
            }
        }

        // Move the actor along the calculated path
        void MoveAlongPath(GameObject actor, CharacterController controller)
        {
            if (_path == null || _path.corners.Length == 0)
            {
                UnityEngine.Debug.LogWarning("Path is invalid or empty.");
                return;
            }

            if (_pathIndex < _path.corners.Length)
            {
                var targetPosition = _path.corners[_pathIndex];
                var direction = (targetPosition - actor.transform.position).normalized;

                // Move the CharacterController
                controller.Move(direction * _speed * Time.deltaTime);

                // Check if the actor has reached the current waypoint
                if (Vector3.Distance(
                        actor.transform.position, targetPosition) <
                    0.1f) _pathIndex++; // Move to the next waypoint in the path
            }
        }
    }
}
