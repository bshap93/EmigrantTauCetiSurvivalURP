using Polyperfect.Crafting.Demo;
using Polyperfect.Crafting.Integration;
using UnityEngine;

namespace Items.Inventory.Scripts
{
    public class EquippedItemListener : MonoBehaviour
    {
        public EquippedSlot equippedSlot;
        public ItemWorldFragmentManager ItemWorldFragmentManager;


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
                var item = ItemWorldFragmentManager.GetItemByID(newItemStack.ID);

                if (item != null)
                {
                    Debug.Log("Equipped item changed: " + item.name);

                    // Perform custom logic for specific items
                    if (item.name == "Laser Gun")
                        Debug.Log("Laser Gun equipped.");
                    else if (item.name == "Health Potion") Debug.Log("Health Potion equipped.");
                }
            }
            else
            {
                Debug.Log("No item equipped.");
            }
        }
    }
}
