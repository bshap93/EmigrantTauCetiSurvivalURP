using Characters.Scripts;
using Core.Events.EventManagers;
using UnityEngine;

namespace Characters.Health.Scripts.Commands
{
    public class DealDamageCommand : IHealthSystemCommand

    {
        public void Execute(IDamageable damageable, float value, ICharacterEventManager eventManager)
        {
            var healthSystem = damageable.GetHealthSystem();
            Debug.Log(
                healthSystem.CharacterName + "'s Health drops from " + healthSystem.CurrentHealth + " to " +
                (healthSystem.CurrentHealth - value));

            healthSystem.CurrentHealth -= value;


            eventManager.TriggerCharacterTakesDamage(damageable, value);
            if (healthSystem.CurrentHealth <= 0)
                eventManager.TriggerCharacterDied(healthSystem.CharacterName);
        }
    }
}
