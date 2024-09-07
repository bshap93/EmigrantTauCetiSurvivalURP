using Environment.Interactables.Scripts;
using Environment.Interactables.Scripts.Commands;

namespace Environment.Interactables.Buttons.Scripts.Commands
{
    public class InteractSimpleCommand : IInteractableInteractCommand
    {
        public void Execute(IInteractable interactable)
        {
            interactable.InteractSimple();
        }
    }
}
