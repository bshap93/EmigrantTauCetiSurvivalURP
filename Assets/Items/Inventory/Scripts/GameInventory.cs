using System.Collections.Generic;
using Items.Scripts;
using UnityEngine;

namespace Items.Inventory.Scripts
{
    public class GameInventory : MonoBehaviour
    {
        public List<GameItem> items = new();
        public int maxInventorySize = 20; // Set your desired limit 

        public bool AddItem(GameItem item)
        {
            if (items.Count >= maxInventorySize)
            {
                Debug.Log("Inventory is full!");
                return false;
            }

            items.Add(item);
            // Update the UI here if applicable
            return true;
        }

        public void RemoveItem(GameItem item)
        {
            items.Remove(item);
            // Update the UI here if applicable
        }
    }
}
