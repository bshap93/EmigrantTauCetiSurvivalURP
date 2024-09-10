using LevelGeneration.Tiles.Doors.Scripts;
using UnityEngine.AI;

namespace Environment.LevelGeneration.Doors.Scripts.Commands.OpenClose
{
    public class OpenHatchCommand : IDoorCommand
    {
        readonly AutoHatch _autoHatch;
        readonly NavMeshObstacle _navMeshObstacle;
        public OpenHatchCommand(AutoHatch autoHatch, NavMeshObstacle navMeshObstacle)
        {
            _autoHatch = autoHatch;
            _navMeshObstacle = navMeshObstacle;
        }

        public void Execute()
        {
            _autoHatch.SetState(AutoHatch.DoorState.Opening);
            _navMeshObstacle.carving = false;
        }
    }
}
