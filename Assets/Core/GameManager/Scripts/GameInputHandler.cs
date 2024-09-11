using Core.Events;
using Core.GameManager.Scripts.Commands;
using Core.InputHandler.Scripts;
using UnityEngine;

namespace Core.GameManager.Scripts
{
    public class GameInputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField] bool isPaused;
        PauseGameCommand _pauseGameCommand;
        ResumeGameCommand _resumeGameCommand;


        void Start()
        {
            isPaused = false;
            _pauseGameCommand = new PauseGameCommand();
            _resumeGameCommand = new ResumeGameCommand();
        }

        void Update()
        {
            HandleInput();
        }
        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    _resumeGameCommand.Execute();
                    EventManager.EResumeGame?.Invoke();
                    isPaused = false;
                }
                else
                {
                    _pauseGameCommand.Execute();
                    EventManager.EPauseGame?.Invoke();
                    isPaused = true;
                }
            }
        }


        void OnPauseGame()
        {
            _pauseGameCommand.Execute();
        }

        void OnResumeGame()
        {
            _resumeGameCommand.Execute();
        }
    }
}
