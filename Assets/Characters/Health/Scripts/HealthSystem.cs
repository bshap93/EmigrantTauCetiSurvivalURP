using Core.Events;
using Core.GameManager.Scripts;
using UI.InGameConsole.Scripts;

namespace Characters.Health.Scripts
{
    public class HealthSystem
    {
        // Event to notify observers when health changes

        readonly InGameConsoleManager _inGameConsoleManager;
        public readonly string CharacterName;

        // Event to notify all subscribers when health changes


        // Updated constructor to include ConsoleManager
        public HealthSystem(string characterName, float maxHealth)
        {
            CharacterName = characterName;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            _inGameConsoleManager = GameManager.Instance.inGameConsoleManager; // Store reference to console manager


            // Subscribe to the OnHealthChanged event
            EventManager.EChangeHealth.AddListener(OnHealthChangedHandler);
        }
        public float MaxHealth { get; }
        public float CurrentHealth { get; set; }

        void OnHealthChangedHandler(float health)
        {
            if (CurrentHealth <= 0) EventManager.ENotifyCharacterDied.Invoke(CharacterName);
        }
    }
}
