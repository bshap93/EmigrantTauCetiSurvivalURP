using Core.Utilities.Commands;
using Environment.Interactables.Openable.Scripts;

namespace Environment.Interactables.Chests.Scripts.Commands
{
    public class CloseChestCommand : ISimpleCommand
    {
        readonly OpenableChest _openableChest;

        public CloseChestCommand(OpenableChest openableChest)
        {
            _openableChest = openableChest;
        }
        public void Execute()
        {
            _openableChest.SetState(OpenableObject.OpenableState.Closing);
        }
    }
}
