using System;
using Core.Systems.Scripts;
using UI.InGameConsole.Scripts;
using UnityEngine;

namespace Characters.Health.Scripts
{
    public class HealthSystem : SystemBase
    {
        // **Highlight**: Added a reference to the ConsoleManager for logging
        readonly ConsoleManager _consoleManager;

        // **Highlight**: Updated constructor to include ConsoleManager
        public HealthSystem(float maxHealth, ConsoleManager consoleManager)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            _consoleManager = consoleManager; // Store reference to console manager
        }
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        // Event to notify observers when health changes
        public event Action<float> OnHealthChanged;

        // Called when the system is activated
        protected override void OnActivate()
        {
            CurrentHealth = MaxHealth;

            // **Highlight**: Log to the console when the HealthSystem is activated
            _consoleManager.LogMessage($"Health System Activated. Starting Health: {CurrentHealth}");
            OnHealthChanged?.Invoke(CurrentHealth); // Notify observers
        }

        protected override void OnDeactivate()
        {
            // Handle cleanup if necessary
        }

        // **Highlight**: Log to the console when damage is taken
        public void TakeDamage(float amount)
        {
            if (!IsActive) return;

            CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
            _consoleManager.LogMessage(
                $"Player took {amount} damage. Current health: {CurrentHealth}"); // Log damage taken

            OnHealthChanged?.Invoke(CurrentHealth); // Notify observers

            if (CurrentHealth <= 0)
            {
                _consoleManager.LogMessage("Player died."); // **Highlight**: Log death to console
                OnDeath();
            }
        }

        // **Highlight**: Log to the console when healing occurs
        public void Heal(float amount)
        {
            if (!IsActive) return;

            CurrentHealth = Mathf.Min(CurrentHealth + amount, MaxHealth);
            _consoleManager.LogMessage($"Player healed by {amount}. Current health: {CurrentHealth}"); // Log healing
            OnHealthChanged?.Invoke(CurrentHealth); // Notify observers
        }

        void OnDeath()
        {
            UnityEngine.Debug.Log("Player died.");
            // Handle death logic
        }
    }
}
