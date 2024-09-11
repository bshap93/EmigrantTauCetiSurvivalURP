using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Characters.Health.Scripts.Debugging
{
    public class CharacterDamageManager : MonoBehaviour
    {
        public UnityEvent<string, float> dealDamage;

        void Awake()
        {
            // Initialize the UnityEvent
            if (dealDamage == null)
                dealDamage = new UnityEvent<string, float>();
        }

        // Button that triggers the UnityEvent
        [Button("Manually Deal Damage (Debug)")]
        public void DebugDealDamage()
        {
            // Trigger the event, passing a damage value (e.g., 10)
            dealDamage?.Invoke("Player", 10f);
        }
    }
}
