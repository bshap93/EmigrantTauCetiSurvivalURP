using Core.GameManager.Scripts.Commands;
using UnityEngine;

namespace UI.ETCCustomCursor.Scripts.Commands
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
