namespace LevelGeneration.Tiles.Doors.Scripts.Commands
{
    public class OpenHatchCommand : IDoorCommand
    {
        readonly AutoHatch _autoHatch;
        public OpenHatchCommand(AutoHatch autoHatch)
        {
            _autoHatch = autoHatch;
        }

        public void Execute()
        {
            _autoHatch.SetState(AutoHatch.DoorState.Opening);
        }
    }
}
