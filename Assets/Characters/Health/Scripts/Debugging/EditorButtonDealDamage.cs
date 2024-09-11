using Core.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Characters.Health.Scripts.Debugging
{
    public class EditorButtonDealDamage : MonoBehaviour
    {
        // Button that triggers the UnityEvent
        [Button("Manually Deal Damage (Debug)")]
        public void DebugDealDamage()
        {
            // Trigger the event, passing a damage value (e.g., 10)
            EventManager.EDealDamage?.Invoke("Player", 10f);
        }
    }
}
