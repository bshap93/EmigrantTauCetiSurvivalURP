namespace LevelGeneration.Tiles.Doors.Scripts.Commands.OpenClose
{
    public class CloseHatchCommand : IDoorCommand
    {
        readonly AutoHatch _autoHatch;

        public CloseHatchCommand(AutoHatch autoHatch)
        {
            _autoHatch = autoHatch;
        }

        public void Execute()
        {
            _autoHatch.SetState(AutoHatch.DoorState.Closing);
        }
    }
}
