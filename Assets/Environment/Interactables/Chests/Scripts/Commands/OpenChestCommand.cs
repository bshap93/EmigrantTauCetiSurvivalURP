using Core.Utilities.Commands;
using Environment.Interactables.Openable.Scripts;

namespace Environment.Interactables.Chests.Scripts.Commands
{
    public class OpenChestCommand : ISimpleCommand
    {
        readonly OpenableChest _openableChest;

        public OpenChestCommand(OpenableChest openableChest)
        {
            _openableChest = openableChest;
        }


        public void Execute()
        {
            _openableChest.SetState(OpenableObject.OpenableState.Opening);
        }
    }
}
