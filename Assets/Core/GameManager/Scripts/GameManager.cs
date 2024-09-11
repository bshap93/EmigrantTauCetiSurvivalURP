using Characters.Health.Scripts;
using Characters.Player.Scripts;
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

        public SaveManager saveManager;
        DisableCursorCommand _disableCursorCommand;

        EnableFreeCursorCommand _enableFreeCursorCommand;

        InGameConsoleManager _inGameConsoleManager;
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
            _inGameConsoleManager = consoleManagerObject.GetComponent<InGameConsoleManager>();

            PlayerStateController.Instance.HealthSystem = new HealthSystem(100, _inGameConsoleManager);


            _disableCursorCommand = new DisableCursorCommand();
            _enableFreeCursorCommand = new EnableFreeCursorCommand();

            _disableCursorCommand.Execute();


            saveManager.InitializedDungeonLevel(null);
        }
    }
}
