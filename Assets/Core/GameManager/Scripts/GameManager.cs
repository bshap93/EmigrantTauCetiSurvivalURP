using Characters.Health.Scripts;
using Characters.Player.Scripts;
using Core.Events.EventManagers;
using Core.SaveSystem.Scripts;
using Items.Inventory.Scripts;
using JetBrains.Annotations;
using UI.ETCCustomCursor.Scripts.Commands;
using UI.InGameConsole.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Core.GameManager.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject consoleManagerObject;


        public UnityEvent<string> onSystemActivated;

        public PlayerEventManager playerEventManager;

        [CanBeNull] public SaveManager saveManager;

        public InGameConsoleManager inGameConsoleManager;

        public ItemWorldFragmentManager itemWorldFragmentManager;
        DisableCursorCommand _disableCursorCommand;

        EnableFreeCursorCommand _enableFreeCursorCommand;
        public static GameManager Instance { get; private set; }


        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }


        void Start()
        {
            inGameConsoleManager = consoleManagerObject.GetComponent<InGameConsoleManager>();

            PlayerCharacter.Instance.HealthSystem =
                new HealthSystem("Player", 100, playerEventManager);


            _disableCursorCommand = new DisableCursorCommand();
            _enableFreeCursorCommand = new EnableFreeCursorCommand();

            _disableCursorCommand.Execute();


            if (saveManager != null) saveManager.InitializedDungeonLevel(null);
        }
    }
}
