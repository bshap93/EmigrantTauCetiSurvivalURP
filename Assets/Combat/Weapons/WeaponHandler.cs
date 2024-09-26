using Characters.Player.Scripts;
using Characters.Scripts;
using Items.Equipment;
using Items.Inventory.Scripts;
using Polyperfect.Crafting.Demo;
using Polyperfect.Crafting.Integration;
using UnityEngine;
using UnityEngine.Serialization;

namespace Combat.Weapons
{
    public class WeaponHandler : EquippableHandler
    {
        public LineRenderer lineRenderer;
        public Transform firePoint;
        public EquippedSlot equippedSlot;
        public ItemWorldFragmentManager itemWorldFragmentManager;
        [FormerlySerializedAs("objectCategory")]
        public CategoryObject weaponCategory;
        [FormerlySerializedAs("currentEquippableItemObject")] [FormerlySerializedAs("currentWeapon")]
        public BaseItemObject currentItemObejct;

        void Start()
        {
            if (equippedSlot != null) equippedSlot.OnContentsChanged.AddListener(OnEquippedItemChanged);
        }
        void OnEquippedItemChanged(ItemStack arg0)
        {
            if (arg0.ID != default)
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
