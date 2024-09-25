using Polyperfect.Crafting.Demo;
using Polyperfect.Crafting.Integration;
using UnityEngine;
using UnityEngine.Serialization;

namespace Items.Inventory.Scripts
{
    public class EquippedItemListener : MonoBehaviour
    {
        public EquippedSlot equippedSlot;
        [FormerlySerializedAs("ItemWorldFragmentManager")]
        public ItemWorldFragmentManager itemWorldFragmentManager;


        void Start()
        {
            if (equippedSlot != null) equippedSlot.OnContentsChanged.AddListener(OnEquippedItemChanged);
        }

        void OnDestroy()
        {
            // Unsubscribe to prevent memory leaks
            if (equippedSlot != null) equippedSlot.OnContentsChanged.RemoveListener(OnEquippedItemChanged);
        }

        void OnEquippedItemChanged(ItemStack newItemStack)
        {
            if (newItemStack.ID != default)
            {
                // Fetch the item using the itemWorldFragmentManager
                var item = itemWorldFragmentManager.GetItemByID(newItemStack.ID);

                if (item != null) Debug.Log("Equipped item changed: " + item.name);

                // if (item.name == "LaserTool")
            }
            else
            {
                Debug.Log("No item equipped.");
            }
        }
    }
}
