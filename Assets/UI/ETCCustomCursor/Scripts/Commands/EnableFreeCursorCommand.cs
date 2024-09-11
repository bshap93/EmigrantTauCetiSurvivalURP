using Core.Utilities.Commands;
using UnityEngine;

namespace UI.ETCCustomCursor.Scripts.Commands
{
    public class EnableFreeCursorCommand : ISimpleCommand
    {
        public void Execute()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
