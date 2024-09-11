using Core.GameManager.Scripts.Commands;
using UnityEngine;

namespace UI.ETCCustomCursor.Scripts.Commands
{
    public class EnableFreeCursorCommand : IGameManageCommand
    {
        public void Execute()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
