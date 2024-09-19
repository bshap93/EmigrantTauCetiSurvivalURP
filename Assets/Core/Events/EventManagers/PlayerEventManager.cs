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
        public UnityEvent playerStateInitializedEvent = new();

        public UnityEvent<string> playerDiedEvent = new();
        public UnityEvent<IDamageable, float> playerTakesDamageEvent = new();

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

        public void AddListenerToCharacterEvent(UnityAction<float> listener)
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

        public void TriggerCharacterChangeHealth(float health)
        {
            playerHealthChangedEvent.Invoke(health);
        }

        public void TriggerCharacterDied(string characterName)
        {
            playerDiedEvent.Invoke(characterName);
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
