using Characters.Scripts;
using Core.Events.EventManagers;
using UnityEngine;
using UnityEngine.Events;

namespace Characters.Enemies
{
    public class EnemyEventManager : MonoBehaviour, ICharacterEventManager
    {
        // Health has changed for a character by a certain amount
        public UnityEvent<float> enemyChangeHealthEvent = new();

        public UnityEvent enemyStateInitializedEvent = new();

        public UnityEvent<string> enemyDiedEvent = new();

        public UnityEvent<IDamageable, float> enemyTakesDamageEvent = new();
        public void TriggerCharacterChangeHealth(float health)
        {
            enemyChangeHealthEvent.Invoke(health);
        }
        public void TriggerCharacterDied(string characterName)
        {
            enemyDiedEvent.Invoke(characterName);
        }
        public void TriggerCharacterTakesDamage(IDamageable damageable, float damage)
        {
            enemyTakesDamageEvent.Invoke(damageable, damage);
        }
        public void TriggerCharacterStateInitialized()
        {
            enemyStateInitializedEvent.Invoke();
        }
        public void AddListenerToCharacterEvent(UnityAction listener)
        {
            enemyStateInitializedEvent.AddListener(listener);
        }
        public void RemoveListenerFromCharacterEvent(UnityAction listener)
        {
            enemyStateInitializedEvent.RemoveListener(listener);
        }
        public void AddListenerToHealthChangedEvent(UnityAction<float> listener)
        {
            enemyChangeHealthEvent.AddListener(listener);
        }
        public void RemoveListenerFromCharacterEvent(UnityAction<float> listener)
        {
            enemyChangeHealthEvent.RemoveListener(listener);
        }
        public void AddListenerToCharacterEvent(UnityAction<string> listener)
        {
            enemyDiedEvent.AddListener(listener);
        }
        public void RemoveListenerFromCharacterEvent(UnityAction<string> listener)
        {
            enemyDiedEvent.RemoveListener(listener);
        }
    }
}
