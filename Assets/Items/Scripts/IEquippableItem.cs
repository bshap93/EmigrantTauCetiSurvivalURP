using Characters.Scripts;
using Polyperfect.Crafting.Integration;

namespace Items.Scripts
{
    public interface IEquippableItem
    {
        void Equip(BaseItemObject item, IDamageable equipper); // Equip the item to the equipper
        void Unequip(BaseItemObject item, IDamageable equipper); // Unequip the item from the equipper
    }
}
