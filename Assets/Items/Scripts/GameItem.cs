using Characters.Player.Scripts;
using UnityEngine;

namespace Items.Scripts
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
    public class GameItem : ScriptableObject
    {
        public int itemID;
        public string itemName;
        public Sprite icon;
        public GameObject prefab;
        public string description;

        // Add properties for equippable and consumable items
        public bool isEquippable;
        public bool isConsumable;

        // For consumables
        public void Use()
        {
            if (isConsumable)
            {
                // For example, heal the player
                var playerStats = FindObjectOfType<PlayerStats>();
                playerStats.Heal(20f);

                // Remove the item from the inventory
            }
        }
    }
}
