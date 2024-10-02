using Core.Utilities.Commands;
using Environment.Interactables.Openable.Scripts;

namespace Environment.Interactables.Doors.Scripts.Commands
{
    public class CloseDoorCommand : ISimpleCommand
    {
        readonly OpenableDoor _openableDoor;

        public CloseDoorCommand(OpenableDoor openableDoor)
        {
            _openableDoor = openableDoor;
        }


        public void Execute()
        {
            _openableDoor.SetState(OpenableObject.OpenableState.Closing);
        }
    }
}
