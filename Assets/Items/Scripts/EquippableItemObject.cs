using Characters.Scripts;
using Items.Equipment;
using Polyperfect.Crafting.Integration;
using UnityEngine;

namespace Items.Scripts
{
    public abstract class EquippableItemObject : BaseItemObject, IEquippableItem
    {
        public float damage;
        public float range;


        public void Equip(IEquippableItem item, IDamageable equipper)
        {
            Debug.Log($"Equipped weapon: {name}");
        }
        public void Unequip(IEquippableItem item, IDamageable equipper)
        {
            Debug.Log($"Unequipped weapon: {name}");
        }


        public abstract void InitializeUseCommand(EquippableHandler equippableHandler);


        public float GetDamage()
        {
            return damage;
        }
    }
}
