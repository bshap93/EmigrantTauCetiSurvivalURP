using Characters.Scripts;

namespace Items.Scripts
{
    public interface IEquippableItem
    {
        void Equip(IDamageable equipper);
        void Unequip(IDamageable equipper);
    }
}
