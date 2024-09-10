using Characters.Health.Scripts;
using DunGen;
using UI.InGameConsole.Scripts;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerCharacter : MonoBehaviour
    {
        DungenCharacter _dungenCharacter;
        Transform _initialOrientation;

        public HealthSystem HealthSystem;
        // public InventorySystem InventorySystem;

        public static PlayerCharacter Instance { get; private set; }

        public float CurrentHealth => HealthSystem.CurrentHealth;


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
            _initialOrientation = transform;
            _dungenCharacter = GetComponent<DungenCharacter>();
            _dungenCharacter.OnTileChanged += OnCharacterTileChanged;
            // This must be done before  GameManager
            HealthSystem = new HealthSystem(100, InGameConsoleManager.Instance);
            // InventorySystem = new InventorySystem();
        }

        public float GetCurrentHealth()
        {
            if (HealthSystem != null)
                return HealthSystem.CurrentHealth;

            return 0;
        }
        public void ResetPlayer()
        {
            HealthSystem.CurrentHealth = HealthSystem.MaxHealth;
        }

        void OnCharacterTileChanged(DungenCharacter character, Tile previousTile, Tile
            newTile)
        {
            Debug.Log("Character moved to a new tile!");
        }
    }
}
