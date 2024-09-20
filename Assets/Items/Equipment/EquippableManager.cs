using System;
using Items.Equippable;
using Items.Inventory.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Items.EquippableScripts
{
    public class EquippableManager : MonoBehaviour
    {
        public static EquippableManager Instance;

        [FormerlySerializedAs("playerInventory")]
        public GameInventory playerGameInventory;

        EquippableItem[] _currentEquipment;

        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            var numSlots = Enum.GetNames(typeof(EquipmentSlot)).Length;
            _currentEquipment = new EquippableItem[numSlots];
        }
        public void Equip(EquippableItem newItem)
        {
            var slotIndex = (int)newItem.equipSlot;

            // Unequip current item in the slot
            if (_currentEquipment[slotIndex] != null) Unequip(slotIndex);

            // Equip the new item
            _currentEquipment[slotIndex] = newItem;

            // Apply stat modifiers, update UI, etc.
        }
        public void Unequip(int slotIndex)
        {
            if (_currentEquipment[slotIndex] != null)
            {
                // Remove stat modifiers, update inventory/UI
                playerGameInventory.AddItem(_currentEquipment[slotIndex]);
                _currentEquipment[slotIndex] = null;
            }
        }
    }
}
