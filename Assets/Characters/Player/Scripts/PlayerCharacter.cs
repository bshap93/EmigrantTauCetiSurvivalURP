using Characters.Enemies.Attacks.Commands;
using Characters.Health.Scripts;
using Characters.Health.Scripts.Commands;
using Characters.Health.Scripts.Debugging;
using Characters.Player.Scripts.States;
using Characters.Scripts;
using Combat.Weapons;
using Combat.Weapons.Scripts;
using Core.Events;
using Core.Events.EventManagers;
using DunGen;
using Items.Equipment;
using JetBrains.Annotations;
using Plugins.DunGen.Code;
using Polyperfect.Crafting.Integration;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Characters.Player.Scripts
{
    public class PlayerCharacter : MonoBehaviour, IDamageable
    {
        public EditorButtonDealDamage editorButtonDealDamage;
        public NavMeshAgent navMeshAgent;
        public PlayerEventManager playerEventManager;
        [SerializeField] PlayerStateController playerStateController;
        [FormerlySerializedAs("weaponHandler")]
        public EquippableHandler equippableHandler;


        [SerializeField] Animator mainPlayerAnimator;
        public BaseItemObject equippedItem;

        DungenCharacter _dungenCharacter;
        Transform _initialOrientation;


        public HealthSystem HealthSystem;

        public Transform Position => transform;

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
            HealthSystem = new HealthSystem("Player", 100, playerEventManager);
            playerStateController.Initialize(this, new ExploreState(null, mainPlayerAnimator));
            playerEventManager.AddListenerToPlayerTakesDamageEvent(TakeDamage);
            EventManager.ERestartCurrentLevel.AddListener(ResetPlayer);
            playerEventManager.TriggerCharacterStateInitialized();
        }

        void OnDestroy()
        {
            _dungenCharacter.OnTileChanged -= OnCharacterTileChanged;
            playerEventManager.RemoveListenerFromPlayerTakesDamageEvent(TakeDamage);
        }

        // Handle debug damage
        public void TakeDamage(IDamageable dmgeable, float damage)
        {
            if ((PlayerCharacter)dmgeable == this)
            {
                var dealDamageCommand = new DealDamageCommand();
                dealDamageCommand.Execute(this, damage, playerEventManager);
            }
        }
        public HealthSystem GetHealthSystem()
        {
            return HealthSystem;
        }
        public void Heal(float value)
        {
            HealthSystem.Heal(value);
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

        public void ChangeState(PlayerState newState)
        {
            playerStateController.ChangeState(newState);
        }

        public PlayerState GetCurrentState()
        {
            return playerStateController.GetCurrentState();
        }
        public BaseItemObject GetEquippedItem()
        {
            return equippedItem;
        }

        public IAttackCommand GetAttackCommand()
        {
            if (equippedItem is Weapon weapon)
            {
                return weapon.GetAttackCommand();
            }

            Debug.LogError("No attack command found");
            return null;
        }
        public void EnterCombatReadyState()
        {
            if (!(playerStateController.GetCurrentState() is RangedCombatReadyState))
                playerStateController.ChangeState(
                    new RangedCombatReadyState(null, mainPlayerAnimator)); // Placeholder for animation
        }


        public void ReturnToExploreState()
        {
            if (!(playerStateController.GetCurrentState() is ExploreState))
                playerStateController.ChangeState(
                    new ExploreState(null, mainPlayerAnimator)); // Placeholder for animation
        }
        public void PerformAttack([CanBeNull] IDamageable target)
        {
            if (equippableHandler is WeaponHandler weaponHandler)
            {
                if (playerStateController.GetCurrentState() is PlayerAttackingState) return;

                if (equippedItem is Weapon weapon)
                    weapon.InitializeUseCommand(weaponHandler);
            }
        }
    }
}
