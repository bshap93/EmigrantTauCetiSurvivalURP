using Core.Events.EventManagers;
using Core.GameManager.Scripts;
using UI.InGameConsole.Scripts;
using UnityEngine.Events;

namespace Characters.Health.Scripts
{
    public class HealthSystem
    {
        readonly ICharacterEventManager _characterEventManager;
        // Event to notify observers when health changes

        readonly InGameConsoleManager _inGameConsoleManager;
        public readonly string CharacterName;

        // Event to notify all subscribers when health changes


        // Updated constructor to include ConsoleManager
        public HealthSystem(string characterName, float maxHealth, ICharacterEventManager characterEventManager)
        {
            CharacterName = characterName;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            _inGameConsoleManager = GameManager.Instance.inGameConsoleManager; // Store reference to console manager

            _characterEventManager = characterEventManager;


            // Subscribe to the OnHealthChanged event
            UnityAction<float> healthChange = OnHealthChangedHandler;
            _characterEventManager.AddListenerToHealthChangedEvent(healthChange);
        }
        public float MaxHealth { get; }
        public float CurrentHealth { get; set; }

        void OnHealthChangedHandler(float health)
        {
            if (CurrentHealth <= 0) _characterEventManager.TriggerCharacterDied(CharacterName);
        }
    }
}
