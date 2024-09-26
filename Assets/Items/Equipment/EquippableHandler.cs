using Characters.Scripts;
using Polyperfect.Crafting.Integration;
using UnityEngine;

namespace Items.Equipment
{
    public abstract class EquippableHandler : MonoBehaviour
    {
        public abstract void Equip(BaseItemObject item, IDamageable equipper);
        public abstract void Unequip(BaseItemObject item, IDamageable equipper);
    }
}
