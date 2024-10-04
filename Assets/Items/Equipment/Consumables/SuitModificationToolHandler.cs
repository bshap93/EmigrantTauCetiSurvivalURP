using Characters.Health.Scripts.States;
using Characters.Scripts;

namespace Items.Equipment.Consumables
{
    public class SuitModificationToolHandler : ConsumableHandler
    {
        public HealthSystem.SuitModificationType suitModificationType;
        public HealthSystem healthSystem;

        public override void Use(IDamageable target)
        {
            healthSystem.RepairSuitHandler(suitModificationType);
        }

        public override void CeaseUsing()
        {
        }
    }
}
