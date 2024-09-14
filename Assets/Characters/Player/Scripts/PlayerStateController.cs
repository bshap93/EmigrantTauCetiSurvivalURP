using Characters.Health.Scripts;
using Characters.Health.Scripts.Commands;
using Characters.Health.Scripts.Debugging;
using Core.Events;
using DunGen;
using Plugins.DunGen.Code;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Characters.Player.Scripts
{
    public class PlayerStateController : MonoBehaviour
    {
        [FormerlySerializedAs("characterDamageManager")]
        [FormerlySerializedAs("dealDamageToCharacter")]
        [FormerlySerializedAs("manuallyDamageCharacter")]
        [FormerlySerializedAs("healthSystemDebug")]
        public EditorButtonDealDamage editorButtonDealDamage;
        public NavMeshAgent navMeshAgent;
        DungenCharacter _dungenCharacter;
        Transform _initialOrientation;


        public HealthSystem HealthSystem;

        public Transform Position => transform;

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
            HealthSystem = new HealthSystem("Player", 100, UIManager.Instance.inGameConsoleManager);
            EventManager.EDealDamage.AddListener(HandleDamage);
            EventManager.ERestartCurrentLevel.AddListener(ResetPlayer);
            EventManager.EPlayerStateInitialized.Invoke();
        }

        [Button("Reset Player")]
        public void ResetPlayer()
        {
            HealthSystem.CurrentHealth = HealthSystem.MaxHealth;
            transform.position = _initialOrientation.position;
            transform.rotation = _initialOrientation.rotation;
        }

        static void OnCharacterTileChanged(DungenCharacter character, Tile previousTile, Tile
            newTile)
        {
            EventManager.EPlayerEnteredRoom.Invoke();
        }

        // Handle debug damage
        void HandleDamage(string character, float damage)
        {
            var dealDamageCommand = new DealDamageCommand();
            dealDamageCommand.Execute(Instance.HealthSystem, damage);
        }
    }
}
