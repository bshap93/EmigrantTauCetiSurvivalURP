using Items.Inventory.Scripts;
using Items.Pickup.Scripts;
using UnityEngine;

namespace Items.Scripts
{
    public class ItemSpawner : MonoBehaviour
    {
        public GameObject itemPickupPrefab;
        public GameInventory playerInventory;

        public void SpawnItem(GameItem item, Vector3 position)
        {
            var pickupObject = Instantiate(itemPickupPrefab, position, Quaternion.identity);
            var pickup = pickupObject.GetComponent<ItemPickup>();
            pickup.item = item;
            pickup.Initialize(playerInventory);
        }
    }
}
