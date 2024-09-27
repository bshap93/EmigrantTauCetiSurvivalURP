using Characters.Player.Scripts;
using Characters.Scripts;
using Core.GameManager.Scripts;
using Items.Equipment;
using Items.Inventory.Scripts;
using Polyperfect.Crafting.Demo;
using Polyperfect.Crafting.Integration;
using UnityEngine;
using UnityEngine.Serialization;

namespace Combat.Weapons
{
    public abstract class WeaponHandler : EquippableHandler
    {
        public Transform firePoint;
        public EquippedSlot equippedSlot;
        public ItemWorldFragmentManager itemWorldFragmentManager;
        [FormerlySerializedAs("objectCategory")]
        public CategoryObject weaponCategory;
        public CategoryWithFloat damageCategory;
        [FormerlySerializedAs("currentEquippableItemObject")] [FormerlySerializedAs("currentWeapon")]
        public BaseItemObject currentItemObejct;

        float _dmaage;

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
                if (weaponCategory.Contains(arg0.ID))
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
            Debug.Log("Equipping weapon: " + item.name);
            gameObject.SetActive(true);
        }
        public override void Unequip(BaseItemObject item, IDamageable equipper)
        {
            Debug.Log("Unequipping weapon: " + item.name);
            gameObject.SetActive(false);
        }
    }
}
