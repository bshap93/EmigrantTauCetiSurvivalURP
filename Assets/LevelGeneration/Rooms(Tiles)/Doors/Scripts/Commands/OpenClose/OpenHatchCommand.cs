namespace LevelGeneration.Tiles.Doors.Scripts.Commands.OpenClose
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
