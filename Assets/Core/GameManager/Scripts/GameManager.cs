using Characters.Health.Scripts;
using Characters.Health.Scripts.Commands;
using Characters.Health.Scripts.Debugging;
using Characters.Player.Scripts;
using Core.SaveSystem.Scripts;
using UI.InGameConsole.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Core.GameManager.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject consoleManagerObject;
        public HealthSystemDebug healthSystemDebug;


        public UnityEvent<string> onSystemActivated;

        public SaveManager saveManager;

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

            PlayerCharacter.Instance.HealthSystem = new HealthSystem(100, _inGameConsoleManager);


            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            healthSystemDebug.onDebugDealDamage.AddListener(HandleDebugDamage);

            saveManager.InitializedDungeonLevel(null);
        }


        void UpdateUI()
        {
        }


        // Handle debug damage
        void HandleDebugDamage(float damage)
        {
            var dealDamageCommand = new DealDamageCommand();
            dealDamageCommand.Execute(PlayerCharacter.Instance.HealthSystem, damage);
        }
    }
}
