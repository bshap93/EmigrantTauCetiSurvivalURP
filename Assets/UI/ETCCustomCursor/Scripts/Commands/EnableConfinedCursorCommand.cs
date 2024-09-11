using Core.Utilities.Commands;
using UnityEngine;

namespace UI.ETCCustomCursor.Scripts.Commands
{
    public class EnableConfinedCursorCommand : ISimpleCommand
    {
        public void Execute()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
