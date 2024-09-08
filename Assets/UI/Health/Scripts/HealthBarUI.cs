using Characters.Health.Scripts;
using Core.GameManager.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Health.Scripts
{
    public class HealthBarUI : MonoBehaviour
    {
        public Image healthBarFill; // Reference to the UI Image for the health bar fill
        HealthSystem _healthSystem; // Reference to the HealthSystem

        void Awake()
        {
            GameManager.Instance.onSystemActivated.AddListener(OnSystemActivated);
            UnityEngine.Debug.Log("HealthBarUI Awake");
        }


        void OnDestroy()
        {
            // Unsubscribe to avoid memory leaks
            _healthSystem.OnHealthChanged -= UpdateHealthBar;
            GameManager.Instance.onSystemActivated.RemoveListener(OnSystemActivated);
        }
        void OnSystemActivated(string systemName)
        {
            if (systemName == "Health")
            {
                UnityEngine.Debug.Log("Health system activated");
                _healthSystem = GameManager.Instance.PlayerHealthSystem; // Get the player's health system
                // Subscribe to health change events
                _healthSystem.OnHealthChanged += UpdateHealthBar;

                // Initialize the health bar with the current health
                UpdateHealthBar(_healthSystem.CurrentHealth);
            }
        }

        // Method to update the health bar fill amount
        void UpdateHealthBar(float currentHealth)
        {
            // Calculate the health percentage and update the fill amount
            var healthPercent = currentHealth / _healthSystem.MaxHealth;
            healthBarFill.fillAmount = healthPercent;
        }
    }
}
