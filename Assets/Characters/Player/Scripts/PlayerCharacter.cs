using Characters.Health.Scripts;
using UI.InGameConsole.Scripts;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerCharacter : MonoBehaviour
    {
        public GameObject player;
        public HealthSystem HealthSystem;

        public static PlayerCharacter Instance { get; private set; }


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
            // This must be done before  GameManager
            HealthSystem = new HealthSystem(100, InGameConsoleManager.Instance);
        }
    }
}
