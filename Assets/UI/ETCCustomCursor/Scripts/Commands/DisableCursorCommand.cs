using Core.Utilities.Commands;
using UnityEngine;

namespace UI.ETCCustomCursor.Scripts.Commands
{
    public class DisableCursorCommand : ISimpleCommand
    {
        public void Execute()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
