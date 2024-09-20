using Items.Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Items.Pickup.Scripts
{
    public class ItemPickup : MonoBehaviour
    {
        public GameItem item;
        GameInventory _inventory;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (_inventory != null)
                {
                    var wasPickedUp = _inventory.AddItem(item);
                    if (wasPickedUp)
                        // Optionally, play a pickup sound or effect
                        Destroy(gameObject); // Remove the item from the scene
                }
                else
                {
                    Debug.LogWarning("Inventory not set on ItemPickup.");
                }
            }
        }


        public void Initialize(GameInventory inventory)
        {
            _inventory = inventory;
        }
    }
}
