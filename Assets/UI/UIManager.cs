using Core.Events;
using Core.GameManager.Scripts;
using Core.GameManager.Scripts.Commands;
using UI.ETCCustomCursor.Scripts;
using UI.Health.Scripts;
using UI.InGameConsole.Scripts;
using UI.Menus.SimpleTextOverlay.Scripts;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] GameObject simpleTextOverlayGameObject;
        public GameInputHandler gameInputHandler;
        public string cursorName;
        public Vector2 cursorHotspot;
        public HealthBarUI healthBarUI;

        public SimpleTextOverlay simpleTextOverlay;

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
            if (simpleTextOverlayGameObject == null)
                simpleTextOverlay = simpleTextOverlayGameObject.GetComponent<SimpleTextOverlay>();

            // Create and set the custom cursor
            _customCursor = new CustomCursor(cursorName, cursorHotspot);


            EventManager.EResumeGame.AddListener(OnResumeGame);
            EventManager.EPauseGame.AddListener(OnPauseGame);

            EventManager.EChangeHealth
                .AddListener(OnHealthChanged);

            EventManager.ENotifyCharacterDied
                .AddListener(OnDead);

            simpleTextOverlayGameObject.SetActive(false);
        }

        void OnDestroy()
        {
            EventManager.EResumeGame.RemoveListener(OnResumeGame);
            EventManager.EPauseGame.RemoveListener(OnPauseGame);

            EventManager.ENotifyCharacterDied
                .RemoveListener(OnDead);

            EventManager.EChangeHealth
                .RemoveListener(OnHealthChanged);
        }

        void OnHealthChanged(float health)
        {
            healthBarUI.UpdateHealthBar(health);
        }


        void OnPauseGame()
        {
            simpleTextOverlayGameObject.GetComponent<SimpleTextOverlay>()
                .SetState(OverlayState.Paused);
        }

        void OnResumeGame()
        {
            simpleTextOverlayGameObject.SetActive(false);
        }

        void OnDead(string character)
        {
            if (character != "Player") return;
            var playerDieCommand = new PlayerDieCommand();
            playerDieCommand.Execute();
            simpleTextOverlayGameObject.GetComponent<SimpleTextOverlay>()
                .SetState(OverlayState.Dead);
        }
    }
}
