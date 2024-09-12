using Core.Utilities.Commands;
using Environment.Interactables.Openable.Scripts;
using UnityEngine.AI;

namespace Environment.LevelGeneration.Doors.Scripts.Commands.OpenClose
{
    public class OpenHatchCommand : ISimpleCommand
    {
        readonly AutoOpeningConnectingDoor _autoOpeningConnectingDoor;
        readonly NavMeshObstacle _navMeshObstacle;
        public OpenHatchCommand(AutoOpeningConnectingDoor autoOpeningConnectingDoor, NavMeshObstacle navMeshObstacle)
        {
            _autoOpeningConnectingDoor = autoOpeningConnectingDoor;
            _navMeshObstacle = navMeshObstacle;
        }

        public void Execute()
        {
            _autoOpeningConnectingDoor.SetState(OpenableObject.OpenableState.Opening);
            _navMeshObstacle.carving = false;
        }
    }
}
