using Characters.Health.Scripts;
using Characters.Player.Scripts;
using Core.Events.EventManagers;
using Core.SaveSystem.Scripts;
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

        public SaveManager saveManager;

        public InGameConsoleManager inGameConsoleManager;
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

            PlayerStateController.Instance.HealthSystem =
                new HealthSystem("Player", 100, playerEventManager);


            _disableCursorCommand = new DisableCursorCommand();
            _enableFreeCursorCommand = new EnableFreeCursorCommand();

            _disableCursorCommand.Execute();


            saveManager.InitializedDungeonLevel(null);
        }
    }
}
