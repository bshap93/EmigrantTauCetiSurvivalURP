﻿using Characters.Health.Scripts.States;
using Core.Events;
using Core.Events.EventManagers;
using Core.GameManager.Scripts;
using Core.GameManager.Scripts.Commands;
using UI.ETCCustomCursor.Scripts;
using UI.Health.Scripts;
using UI.InGameConsole.Scripts;
using UI.Menus.SimpleTextOverlay.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        static readonly int Hit = Animator.StringToHash("Hit");
        [SerializeField] GameObject simpleTextOverlayGameObject;
        public GameInputHandler gameInputHandler;
        public string cursorName;
        public Vector2 cursorHotspot;
        [FormerlySerializedAs("healthBarUI")] [FormerlySerializedAs("statsBarUI")]
        public SuitIntegrityHealthBarUI suitIntegrityHealthBarUI;
        public OxygenBarUI oxygenBarUI;

        [SerializeField] HealthSystem healthSystem;

        public PlayerEventManager playerEventManager;

        public SimpleTextOverlay simpleTextOverlay;

        public InGameConsoleManager inGameConsoleManager;

        public GameObject statusEffectOverlay;

        public Canvas uiCanvas;
        CustomCursor _customCursor;
        Animator _statusEffectOverlayAnimator;


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

            UnityAction<float, bool> healthChange = OnHealthChanged;
            playerEventManager.AddListenerToHealthChangedEvent(healthChange);

            UnityAction<float> oxygenChange = OnOxygenChanged;
            playerEventManager.AddListenerToOxygenChangedEvent(oxygenChange);

            UnityAction<string> dead = OnDead;
            playerEventManager.AddListenerToCharacterEvent(dead);


            simpleTextOverlayGameObject.SetActive(false);

            _statusEffectOverlayAnimator = statusEffectOverlay.GetComponent<Animator>();
        }

        void OnDestroy()
        {
            EventManager.EResumeGame.RemoveListener(OnResumeGame);
            EventManager.EPauseGame.RemoveListener(OnPauseGame);

            UnityAction<float, bool> healthChange = OnHealthChanged;
            playerEventManager.RemoveListenerFromSuitIntegrityChange(healthChange);

            UnityAction<float> oxygenChange = OnOxygenChanged;
            playerEventManager.RemoveListenerFromOxygenChange(oxygenChange);

            UnityAction<string> dead = OnDead;
            playerEventManager.RemoveListenerFromCharacterEvent(dead);
        }


        void OnHealthChanged(float health, bool damage)
        {
            // If it's decreasing, play the animation
            if (damage) _statusEffectOverlayAnimator.SetTrigger(Hit);
            suitIntegrityHealthBarUI.UpdateSuitIntegrityBar(health);
        }

        void OnOxygenChanged(float oxygen)
        {
            oxygenBarUI.UpdateOxygenBar(oxygen);
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
