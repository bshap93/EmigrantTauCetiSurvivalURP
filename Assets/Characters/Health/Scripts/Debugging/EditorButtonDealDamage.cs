using Characters.Player.Scripts;
using Core.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Characters.Health.Scripts.Debugging
{
    public class EditorButtonDealDamage : MonoBehaviour
    {
        // Button that triggers the UnityEvent
        [Button("Manually Deal Damage (Debug)")]
        public PlayerStateController playerStateController;
        public void DebugDealDamage()
        {
            // Trigger the event, passing a damage value (e.g., 10)
            EventManager.EDealDamage?.Invoke(playerStateController, 10f);
        }
    }
}
