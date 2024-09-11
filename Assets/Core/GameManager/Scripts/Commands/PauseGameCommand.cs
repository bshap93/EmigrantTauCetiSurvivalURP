using Core.Utilities.Commands;
using UnityEngine;

namespace Core.GameManager.Scripts.Commands
{
    public class PauseGameCommand : ISimpleCommand
    {
        public void Execute()
        {
            // puaseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
