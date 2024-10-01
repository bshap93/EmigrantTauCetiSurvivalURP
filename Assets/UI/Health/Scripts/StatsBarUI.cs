using System;
using Characters.Health.Scripts.States;
using Characters.Player.Scripts;
using Core.Events.EventManagers;
using Core.GameManager.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
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
        [FormerlySerializedAs("_healthSystem")] [SerializeField]
        HealthSystem healthSystem; // Reference to the HealthSystem


        void Start()
        {
            GameManager.Instance.onSystemActivated.AddListener(OnSystemActivated);
            healthSystem = PlayerCharacter.Instance.GetHealthSystem(); // Get the player's health system
            if (playerEventManager == null) playerEventManager = GameManager.Instance.playerEventManager;


            // Initialize the health bar with the current health
            if (statType == StatType.SuitIntegrity)
                UpdateSuitIntegrityBar(healthSystem.currentSuitIntegrity);
            else if (statType == StatType.Oxygen)
                UpdateOxygenBar(healthSystem.currentOxygen);
        }

        void Update()
        {
            if (statType == StatType.SuitIntegrity)
                UpdateSuitIntegrityBar(healthSystem.currentSuitIntegrity);
            else if (statType == StatType.Oxygen)
                UpdateOxygenBar(healthSystem.currentOxygen);
        }


        void OnSystemActivated(string systemName)
        {
            if (systemName == "Health")
            {
                Debug.Log("Health system activated");
                healthSystem = PlayerCharacter.Instance.GetHealthSystem(); // Get the player's health system
                // Subscribe to health change events
                if (statType == StatType.SuitIntegrity)
                {
                    UnityAction<float> healthChange = currentHealth => UpdateSuitIntegrityBar(currentHealth);
                    playerEventManager.AddListenerToHealthChangedEvent(healthChange);
                    // Initialize the health bar with the current health
                    UpdateSuitIntegrityBar(healthSystem.currentSuitIntegrity);
                }
                else if (statType == StatType.Oxygen)
                {
                    UnityAction<float> oxygenChange = currentOxygen => UpdateOxygenBar(currentOxygen);
                    playerEventManager.AddListenerToOxygenChangedEvent(oxygenChange);
                    UpdateOxygenBar(healthSystem.currentOxygen);
                }
            }
        }

        // Method to update the health bar fill amount
        public void UpdateSuitIntegrityBar(float value)
        {
            // Calculate the health percentage and update the fill amount
            var healthPercent = value / healthSystem.maxSuitIntegrity;
            healthBarFill.fillAmount = healthPercent;
        }

        public void UpdateOxygenBar(float value)
        {
            // Calculate the health percentage and update the fill amount
            var healthPercent = value / healthSystem.maxOxygen;
            healthBarFill.fillAmount = healthPercent;
        }
    }
}
