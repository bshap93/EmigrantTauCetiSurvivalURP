using Core.Utilities.Commands;
using Environment.Interactables.Openable.Scripts;
using UnityEngine.AI;

namespace Environment.LevelGeneration.Doors.Scripts.Commands.OpenClose
{
    public class CloseHatchCommand : ISimpleCommand
    {
        readonly AutoOpeningConnectingDoor _autoOpeningConnectingDoor;

        readonly NavMeshObstacle _navMeshObstacle;
        public CloseHatchCommand(AutoOpeningConnectingDoor autoOpeningConnectingDoor, NavMeshObstacle navMeshObstacle)
        {
            _autoOpeningConnectingDoor = autoOpeningConnectingDoor;
            _navMeshObstacle = navMeshObstacle;
        }

        public void Execute()
        {
            _autoOpeningConnectingDoor.SetState(OpenableObject.OpenableState.Closing);
            _navMeshObstacle.carving = true;
        }
    }
}
