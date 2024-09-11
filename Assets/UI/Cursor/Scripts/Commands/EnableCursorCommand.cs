using UnityEngine;

namespace Core.GameManager.Scripts.Commands
{
    public class EnableCursorCommand : IGameManageCommand
    {
        public void Execute()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
