﻿using Characters.Health.Scripts;
using Characters.Health.Scripts.Commands;
using Characters.Health.Scripts.Debugging;
using Characters.Scripts;
using Core.Events;
using DunGen;
using Plugins.DunGen.Code;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Characters.Player.Scripts
{
    public class PlayerStateController : MonoBehaviour, IDamageable
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
            HealthSystem = new HealthSystem("Player", 100);
            EventManager.EDealDamage.AddListener(TakeDamage);
            EventManager.ERestartCurrentLevel.AddListener(ResetPlayer);
            EventManager.EPlayerStateInitialized.Invoke();
        }

        // Handle debug damage
        public void TakeDamage(IDamageable dmgeable, float damage)
        {
            if ((PlayerStateController)dmgeable == this)
            {
                var dealDamageCommand = new DealDamageCommand();
                dealDamageCommand.Execute(Instance.HealthSystem, damage);
            }
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
    }
}
