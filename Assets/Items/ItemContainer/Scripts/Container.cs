using System.Collections.Generic;
using Items.Inventory.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Items.ItemContainer.Scripts
{
    public class Container : MonoBehaviour
    {
        public GameInventory inventory;
        public int maxInventorySize = 20; // Set your desired limit

        void Awake()
        {
            inventory = gameObject.AddComponent<GameInventory>();
            inventory.maxInventorySize = maxInventorySize; // Set the container size
        }

        public List<GameItem> GetItems()
        {
            return inventory.items;
        }
    }
}
