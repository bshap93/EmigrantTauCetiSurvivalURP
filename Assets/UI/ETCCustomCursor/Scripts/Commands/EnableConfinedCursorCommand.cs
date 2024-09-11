using Core.GameManager.Scripts.Commands;
using UnityEngine;

namespace UI.ETCCustomCursor.Scripts.Commands
{
    public class EnableConfinedCursorCommand : IGameManageCommand
    {
        public void Execute()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
