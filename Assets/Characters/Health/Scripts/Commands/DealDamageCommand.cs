using Core.Events;
using UnityEngine;

namespace Characters.Health.Scripts.Commands
{
    public class DealDamageCommand : IHealthSystemCommand

    {
        public void Execute(HealthSystem healthSystem, float value)
        {
            Debug.Log(
                "Health drops from " + healthSystem.CurrentHealth + " to " + (healthSystem.CurrentHealth - value));

            healthSystem.CurrentHealth -= value;
            EventManager.EChangeHealth.Invoke(healthSystem.CurrentHealth - value);
            if (healthSystem.CurrentHealth <= 0) EventManager.ENotifyCharacterDied.Invoke(healthSystem.CharacterName);
        }
    }
}
