using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Characters.Health.Scripts.Debugging
{
    public class HealthSystemDebug : MonoBehaviour
    {
        // UnityEvent that the GameManager will subscribe to for dealing damage
        public UnityEvent<float> onDebugDealDamage;

        void Awake()
        {
            // Initialize the UnityEvent
            if (onDebugDealDamage == null)
                onDebugDealDamage = new UnityEvent<float>();
        }

        // Button that triggers the UnityEvent
        [Button("Deal Damage (Debug)")]
        public void DebugDealDamage()
        {
            // Trigger the event, passing a damage value (e.g., 10)
            onDebugDealDamage?.Invoke(10f);
        }
    }
}
