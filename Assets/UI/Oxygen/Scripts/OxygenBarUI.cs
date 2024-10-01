using Characters.Health.Scripts.States;
using Characters.Player.Scripts;
using Core.Events.EventManagers;
using Core.GameManager.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Oxygen.Scripts
{
    public class OxygenBarUI : MonoBehaviour
    {
        public Image oxygenBar; // Reference to the UI Image for the health bar fill
        public PlayerEventManager playerEventManager;
        HealthSystem _healthSystem; // Reference to the HealthSystem


        void Start()
        {
            GameManager.Instance.onSystemActivated.AddListener(OnSystemActivated);
            _healthSystem = PlayerCharacter.Instance.GetHealthSystem(); // Get the player's health system
            if (playerEventManager == null) playerEventManager = GameManager.Instance.playerEventManager;


            // Initialize the health bar with the current health
            UpdateHealthBar(_healthSystem.CurrentSuitIntegrity);
        }


        void OnSystemActivated(string systemName)
        {
            if (systemName == "Health")
            {
                Debug.Log("Health system activated");
                _healthSystem = PlayerCharacter.Instance.GetHealthSystem(); // Get the player's health system
                // Subscribe to health change events
                UnityAction<float> healthChange = UpdateHealthBar;
                playerEventManager.AddListenerToHealthChangedEvent(healthChange);

                // Initialize the health bar with the current health
                UpdateHealthBar(_healthSystem.CurrentSuitIntegrity);
            }
        }

        // Method to update the health bar fill amount
        public void UpdateHealthBar(float currentHealth)
        {
            // Calculate the health percentage and update the fill amount
            var healthPercent = currentHealth / _healthSystem.MaxSuitIntegrity;
            oxygenBar.fillAmount = healthPercent;
        }
    }
}
