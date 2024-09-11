using System;
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

        public static GameInputHandler Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

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
            if (Input.GetKey(KeyCode.Escape))
            {
                if (isPaused)
                {
                    _resumeGameCommand.Execute();
                    ResumeGame?.Invoke();
                    isPaused = false;
                }
                else
                {
                    _pauseGameCommand.Execute();
                    PauseGame?.Invoke();
                    isPaused = true;
                }
            }
        }
        public event Action ResumeGame;
        public event Action PauseGame;

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
