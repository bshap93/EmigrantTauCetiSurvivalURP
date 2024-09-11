using UI.InGameConsole.Scripts;
using UnityEngine.Events;

namespace Characters.Health.Scripts
{
    public class HealthSystem
    {
        // Event to notify observers when health changes

        readonly InGameConsoleManager _inGameConsoleManager;
        public readonly UnityEvent<string> CharacterDied;
        public readonly string CharacterName;

        // Event to notify all subscribers when health changes
        public readonly UnityEvent<float> OnHealthChanged;

        // Updated constructor to include ConsoleManager
        public HealthSystem(string characterName, float maxHealth, InGameConsoleManager inGameConsoleManager)
        {
            CharacterName = characterName;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            _inGameConsoleManager = inGameConsoleManager; // Store reference to console manager

            OnHealthChanged = new UnityEvent<float>();
            CharacterDied = new UnityEvent<string>();

            // Subscribe to the OnHealthChanged event
            OnHealthChanged.AddListener(OnHealthChangedHandler);
        }
        public float MaxHealth { get; }
        public float CurrentHealth { get; set; }

        void OnHealthChangedHandler(float health)
        {
            if (CurrentHealth <= 0) CharacterDied.Invoke(CharacterName);
        }
    }
}
