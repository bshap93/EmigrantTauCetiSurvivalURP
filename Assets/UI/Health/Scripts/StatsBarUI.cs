using System;
using Characters.Health.Scripts.States;
using Characters.Player.Scripts;
using Core.Events.EventManagers;
using Core.GameManager.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Health.Scripts
{
    public class StatsBarUI : MonoBehaviour
    {
        [Serializable]
        public enum StatType
        {
            SuitIntegrity,
            Oxygen
        }

        public StatType statType; // The type of stat to display
        public Image healthBarFill; // Reference to the UI Image for the health bar fill
        public PlayerEventManager playerEventManager;
        HealthSystem _healthSystem; // Reference to the HealthSystem


        void Start()
        {
            GameManager.Instance.onSystemActivated.AddListener(OnSystemActivated);
            _healthSystem = PlayerCharacter.Instance.GetHealthSystem(); // Get the player's health system
            if (playerEventManager == null) playerEventManager = GameManager.Instance.playerEventManager;


            // Initialize the health bar with the current health
            if (statType == StatType.SuitIntegrity)
                UpdateStatsBar(_healthSystem.CurrentSuitIntegrity);
            else if (statType == StatType.Oxygen)
                UpdateStatsBar(_healthSystem.CurrentOxygen);
        }


        void OnSystemActivated(string systemName)
        {
            if (systemName == "Health")
            {
                Debug.Log("Health system activated");
                _healthSystem = PlayerCharacter.Instance.GetHealthSystem(); // Get the player's health system
                // Subscribe to health change events
                UnityAction<float> healthChange = currentHealth => UpdateStatsBar(currentHealth);
                playerEventManager.AddListenerToHealthChangedEvent(healthChange);

                // Initialize the health bar with the current health
                UpdateStatsBar(_healthSystem.CurrentSuitIntegrity);
            }
        }

        // Method to update the health bar fill amount
        public void UpdateStatsBar(float value)
        {
            // Calculate the health percentage and update the fill amount
            var healthPercent = value / _healthSystem.MaxSuitIntegrity;
            healthBarFill.fillAmount = healthPercent;
        }
    }
}
