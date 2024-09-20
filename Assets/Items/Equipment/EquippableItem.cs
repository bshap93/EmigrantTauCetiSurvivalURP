using Items.EquippableScripts;
using Items.Scripts;

namespace Items.Equippable
{
    public class EquippableItem : GameItem
    {
        public EquipmentSlot equipSlot;
        public int attackModifier;
        public int defenseModifier;

        // Override Use method if necessary
        public void Equip()
        {
            // Equip the item
            EquippableManager.Instance.Equip(this);
        }
    }
}
