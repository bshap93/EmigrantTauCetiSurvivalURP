using Characters.Player.Scripts;
using Core.GameManager.Scripts;
using UI.ETCCustomCursor.Scripts;
using UI.Health.Scripts;
using UI.InGameConsole.Scripts;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public GameObject pauseOverlay;
        public GameInputHandler gameInputHandler;
        public string cursorName;
        public Vector2 cursorHotspot;
        public HealthBarUI healthBarUI;

        public InGameConsoleManager inGameConsoleManager;
        CustomCursor _customCursor;
        public static UIManager Instance { get; private set; }

        void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }


        void Start()
        {
            // Create and set the custom cursor
            _customCursor = new CustomCursor(cursorName, cursorHotspot);


            gameInputHandler.PauseGame += OnPauseGame;
            gameInputHandler.ResumeGame += OnResumeGame;

            PlayerStateController.Instance.HealthSystem.OnHealthChanged
                .AddListener(OnHealthChanged);

            pauseOverlay.SetActive(false);
        }

        void OnDestroy()
        {
            gameInputHandler.PauseGame -= OnPauseGame;
            gameInputHandler.ResumeGame -= OnResumeGame;

            PlayerStateController.Instance.HealthSystem.OnHealthChanged
                .RemoveListener(OnHealthChanged);
        }

        void OnHealthChanged(float health)
        {
            healthBarUI.UpdateHealthBar(health);
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
