using Characters.Health.Scripts.States;
using Characters.Scripts;
using Polyperfect.Crafting.Integration;

namespace Items.Equipment.Consumables
{
    public class SuitModificationToolHandler : ConsumableHandler
    {
        public HealthSystem.SuitModificationType suitModificationType;
        public HealthSystem healthSystem;
        public ChildSlotsInventory hotbarInventory;

        public override void Use(IDamageable target)
        {
            healthSystem.RepairSuitHandler(suitModificationType);
            hotbarInventory.RemoveItem(currentItemObejct.ID);
        }

        public override void CeaseUsing()
        {
        }
    }
}
