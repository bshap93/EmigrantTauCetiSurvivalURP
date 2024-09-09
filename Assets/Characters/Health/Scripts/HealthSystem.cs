using UI.InGameConsole.Scripts;
using UnityEngine.Events;

namespace Characters.Health.Scripts
{
    public class HealthSystem
    {
        // Event to notify observers when health changes

        readonly InGameConsoleManager _inGameConsoleManager;

        // Event to notify all subscribers when health changes
        public readonly UnityEvent<float> OnHealthChanged;

        // Updated constructor to include ConsoleManager
        public HealthSystem(float maxHealth, InGameConsoleManager inGameConsoleManager)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            _inGameConsoleManager = inGameConsoleManager; // Store reference to console manager

            OnHealthChanged = new UnityEvent<float>();
        }
        public float MaxHealth { get; }
        public float CurrentHealth { get; set; }
    }
}
