using Characters.Health.Scripts;
using Characters.Health.Scripts.Commands;
using Characters.Health.Scripts.Debugging;
using DunGen;
using Plugins.DunGen.Code;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Characters.Player.Scripts
{
    public class PlayerStateController : MonoBehaviour
    {
        [FormerlySerializedAs("healthSystemDebug")]
        public ManuallyDamageCharacter manuallyDamageCharacter;
        DungenCharacter _dungenCharacter;
        Transform _initialOrientation;

        public HealthSystem HealthSystem;
        // public InventorySystem InventorySystem;

        public static PlayerStateController Instance { get; private set; }

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
            HealthSystem = new HealthSystem(100, UIManager.Instance.inGameConsoleManager);
            manuallyDamageCharacter.onDebugDealDamage.AddListener(HandleDebugDamage);
        }

        [Button("Reset Player")]
        public void ResetPlayer()
        {
            HealthSystem.CurrentHealth = HealthSystem.MaxHealth;
            transform.position = _initialOrientation.position;
            transform.rotation = _initialOrientation.rotation;
        }

        void OnCharacterTileChanged(DungenCharacter character, Tile previousTile, Tile
            newTile)
        {
            Debug.Log("Character moved to a new tile!");
        }

        // Handle debug damage
        void HandleDebugDamage(float damage)
        {
            var dealDamageCommand = new DealDamageCommand();
            dealDamageCommand.Execute(Instance.HealthSystem, damage);
        }
    }
}
