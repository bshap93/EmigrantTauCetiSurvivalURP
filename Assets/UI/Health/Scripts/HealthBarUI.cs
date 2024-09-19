using Characters.Health.Scripts;
using Characters.Player.Scripts;
using Core.Events.EventManagers;
using Core.GameManager.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Health.Scripts
{
    public class HealthBarUI : MonoBehaviour
    {
        public Image healthBarFill; // Reference to the UI Image for the health bar fill
        public PlayerEventManager playerEventManager;
        HealthSystem _healthSystem; // Reference to the HealthSystem


        void Start()
        {
            GameManager.Instance.onSystemActivated.AddListener(OnSystemActivated);
            _healthSystem = PlayerCharacter.Instance.HealthSystem; // Get the player's health system


            // Initialize the health bar with the current health
            UpdateHealthBar(_healthSystem.CurrentHealth);
        }

        void OnDestroy()
        {
            // Unsubscribe to avoid memory leaks
            GameManager.Instance.onSystemActivated.RemoveListener(OnSystemActivated);
        }


        void OnSystemActivated(string systemName)
        {
            if (systemName == "Health")
            {
                Debug.Log("Health system activated");
                _healthSystem = PlayerCharacter.Instance.HealthSystem; // Get the player's health system
                // Subscribe to health change events
                UnityAction<float> healthChange = UpdateHealthBar;
                playerEventManager.AddListenerToCharacterEvent(healthChange);

                // Initialize the health bar with the current health
                UpdateHealthBar(_healthSystem.CurrentHealth);
            }
        }

        // Method to update the health bar fill amount
        public void UpdateHealthBar(float currentHealth)
        {
            // Calculate the health percentage and update the fill amount
            var healthPercent = currentHealth / _healthSystem.MaxHealth;
            healthBarFill.fillAmount = healthPercent;
        }
    }
}
