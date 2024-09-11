using UnityEngine;

namespace Core.GameManager.Scripts.Commands
{
    public class PauseGameCommand : IGameManageCommand
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
