using Characters.Health.Scripts;
using UI.InGameConsole.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Core.GameManager.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject consoleManagerObject;

        public UnityEvent<string> onSystemActivated;

        ConsoleManager _consoleManager;
        public static GameManager Instance { get; private set; }

        public HealthSystem PlayerHealthSystem { get; private set; }

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }


        void Start()
        {
            _consoleManager = consoleManagerObject.GetComponent<ConsoleManager>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PlayerHealthSystem = new HealthSystem(100, _consoleManager);
            PlayerHealthSystem.Activate();
            UnityEngine.Debug.Log("HealthSystem Activated");
            onSystemActivated.Invoke("Health");
        }
    }
}
