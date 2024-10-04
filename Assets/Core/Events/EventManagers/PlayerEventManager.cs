using Characters.Health.Scripts.States;
using Characters.Player.Scripts;
using Characters.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events.EventManagers
{
    public class PlayerEventManager : MonoBehaviour, ICharacterEventManager
    {
        // Health has changed for a character by a certain amount
        public UnityEvent<float> playerHealthChangedEvent = new();
        // Oxygen has changed for a character by a certain amount
        public UnityEvent<float> playerOxygenChangedEvent = new();
        public UnityEvent playerStateInitializedEvent = new();

        public UnityEvent<string> playerDiedEvent = new();
        public UnityEvent<IDamageable, float> playerTakesDamageEvent = new();
        public UnityEvent<HealthSystem.SuitModificationType> playerSuitRepairEvent = new();

        public PlayerCharacter player;

        // Encapsulate AddListener logic
        public void TriggerCharacterTakesDamage(IDamageable damageable, float damage)
        {
            playerTakesDamageEvent.Invoke(damageable, damage);
        }
        public void TriggerCharacterStateInitialized()
        {
            playerStateInitializedEvent.Invoke();
        }
        public void AddListenerToCharacterEvent(UnityAction listener)
        {
            playerStateInitializedEvent.AddListener(listener);
        }

        // Optionally expose RemoveListener for cleanup
        public void RemoveListenerFromCharacterEvent(UnityAction listener)
        {
            playerStateInitializedEvent.RemoveListener(listener);
        }

        public void AddListenerToHealthChangedEvent(UnityAction<float> listener)
        {
            playerHealthChangedEvent.AddListener(listener);
        }

        // Optionally expose RemoveListener for cleanup
        public void RemoveListenerFromCharacterEvent(UnityAction<float> listener)
        {
            playerHealthChangedEvent.RemoveListener(listener);
        }
        public void AddListenerToCharacterEvent(UnityAction<string> listener)
        {
            playerDiedEvent.AddListener(listener);
        }
        public void RemoveListenerFromCharacterEvent(UnityAction<string> listener)
        {
            playerDiedEvent.RemoveListener(listener);
        }
        public void AddListenerToOxygenChangedEvent(UnityAction<float> oxygenChange)
        {
            playerOxygenChangedEvent.AddListener(oxygenChange);
        }
        public void AddListenerToSuitRepairEvent(UnityAction<HealthSystem.SuitModificationType> suitModType)
        {
            playerSuitRepairEvent.AddListener(suitModType);
        }
        public void RemoveListenerFromOxygenChangedEvent(UnityAction<float> oxygenChange)
        {
            playerOxygenChangedEvent.RemoveListener(oxygenChange);
        }

        public void TriggerCharacterChangeHealth(float health)
        {
            playerHealthChangedEvent.Invoke(health);
        }
        public void TriggerCharacterChangeOxygen(float oxygen)
        {
            playerOxygenChangedEvent.Invoke(oxygen);
        }

        public void TriggerCharacterDied(string characterName)
        {
            playerDiedEvent.Invoke(characterName);
        }

        public void TriggerCharacterSuitRepair(HealthSystem.SuitModificationType suitModType)
        {
            playerSuitRepairEvent.Invoke(suitModType);
        }

        public void AddListenerToPlayerTakesDamageEvent(UnityAction<IDamageable, float> listener)
        {
            playerTakesDamageEvent.AddListener(listener);
        }

        public void RemoveListenerFromPlayerTakesDamageEvent(UnityAction<IDamageable, float> listener)

        {
            playerTakesDamageEvent.RemoveListener(listener);
        }
    }
}
