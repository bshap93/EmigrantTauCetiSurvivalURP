using UnityEngine;

namespace Core.GameManager.Scripts.Commands
{
    public class DisableCursorCommand : IGameManageCommand
    {
        public void Execute()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
