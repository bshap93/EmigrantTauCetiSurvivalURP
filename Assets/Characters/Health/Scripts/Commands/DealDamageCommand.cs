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
            healthSystem.OnHealthChanged.Invoke(healthSystem.CurrentHealth - value);
        }
    }
}
