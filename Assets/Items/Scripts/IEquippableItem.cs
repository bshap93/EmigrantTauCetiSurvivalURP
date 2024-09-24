using Characters.Scripts;

namespace Items.Scripts
{
    public interface IEquippableItem
    {
        void Equip(IEquippableItem item, IDamageable equipper); // Equip the item to the equipper
        void Unequip(IEquippableItem item, IDamageable equipper); // Unequip the item from the equipper
    }
}
