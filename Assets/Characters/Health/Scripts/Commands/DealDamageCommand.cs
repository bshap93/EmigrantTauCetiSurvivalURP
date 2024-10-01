using Characters.Enemies;
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
            if (damageable is Enemy)
                Debug.Log(
                    healthSystem.CharacterName + "'s Health drops from " + healthSystem.CurrentSuitIntegrity + " to " +
                    (healthSystem.CurrentSuitIntegrity - value));

            healthSystem.CurrentSuitIntegrity -= value;


            eventManager.TriggerCharacterChangeHealth(healthSystem.CurrentSuitIntegrity);
            if (healthSystem.CurrentSuitIntegrity <= 0)
                eventManager.TriggerCharacterDied(healthSystem.CharacterName);
        }
    }
}
