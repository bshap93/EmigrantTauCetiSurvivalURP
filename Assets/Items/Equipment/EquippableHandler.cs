using Characters.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Items.Equipment
{
    public abstract class EquippableHandler : MonoBehaviour
    {
        public abstract void Equip(IEquippableItem item, IDamageable equipper);
        public abstract void Unequip(IEquippableItem item, IDamageable equipper);
    }
}
