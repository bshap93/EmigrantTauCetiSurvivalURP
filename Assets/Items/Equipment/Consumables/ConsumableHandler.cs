using System;
using Characters.Player.Scripts;
using Characters.Scripts;
using Core.GameManager.Scripts;
using Polyperfect.Crafting.Demo;
using Polyperfect.Crafting.Integration;
using UnityEngine;

namespace Items.Equipment.Consumables
{
    public class ConsumableHandler : EquippableHandler
    {
        public CategoryObject consumableCategory;
        void Start()
        {
            if (equippedSlot != null) equippedSlot.OnContentsChanged.AddListener(OnEquippedItemChanged);
            equippedSlot = PlayerCharacter.Instance.gameObject.GetComponentInChildren<EquippedSlot>();
            itemWorldFragmentManager = GameManager.Instance.itemWorldFragmentManager;
        }

        void OnEquippedItemChanged(ItemStack arg0)
        {
            if (arg0.ID != default && arg0.ID == currentItemObejct.ID)
            {
                if (consumableCategory.Contains(arg0.ID))
                {
                    var item = itemWorldFragmentManager.GetItemByID(arg0.ID);

                    Equip(item, PlayerCharacter.Instance);
                }
            }
            else
            {
                Unequip(currentItemObejct, PlayerCharacter.Instance);
            }
        }

        public override void Equip(BaseItemObject item, IDamageable equipper)
        {
            Debug.Log("Equipping consumable: " + item.name);
            currentItemObejct = item;
            PlayerCharacter.Instance.equippedItem = item;
            PlayerCharacter.Instance.equippableHandler = this;
        }

        public override void Unequip(BaseItemObject item, IDamageable equipper)
        {
            if (PlayerCharacter.Instance.equippedItem == null &&
                PlayerCharacter.Instance.equippableHandler == this)
                return;

            Debug.Log("Unequipping consumable: " + item.name);
            currentItemObejct = null;
            PlayerCharacter.Instance.equippedItem = null;
            PlayerCharacter.Instance.equippableHandler = null;
        }
        public override void Use(IDamageable target)
        {
            throw new NotImplementedException();
        }
        public override void CeaseUsing()
        {
            throw new NotImplementedException();
        }
    }
}
