using Core.Events.EventManagers;
using UnityEngine;

namespace Characters.Health.Scripts.Commands
{
    public class DealDamageCommand : IHealthSystemCommand

    {
        public void Execute(HealthSystem healthSystem, float value, ICharacterEventManager eventManager)
        {
            Debug.Log(
                "Health drops from " + healthSystem.CurrentHealth + " to " + (healthSystem.CurrentHealth - value));

            healthSystem.CurrentHealth -= value;


            eventManager.TriggerCharacterChangeHealth(healthSystem.CurrentHealth - value);
            if (healthSystem.CurrentHealth <= 0)
                eventManager.TriggerCharacterDied(healthSystem.CharacterName);
        }
    }
}
