using Core.GameManager.Scripts;
using UI.ETCCustomCursor.Scripts;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public GameObject pauseOverlay;
        public GameInputHandler gameInputHandler;
        public string cursorName;
        public Vector2 cursorHotspot;
        CustomCursor _customCursor;


        void Start()
        {
            // Create and set the custom cursor
            _customCursor = new CustomCursor(cursorName, cursorHotspot);

            gameInputHandler.PauseGame += OnPauseGame;
            gameInputHandler.ResumeGame += OnResumeGame;

            pauseOverlay.SetActive(false);
        }

        void OnPauseGame()
        {
            pauseOverlay.SetActive(true);
        }

        void OnResumeGame()
        {
            pauseOverlay.SetActive(false);
        }
    }
}
