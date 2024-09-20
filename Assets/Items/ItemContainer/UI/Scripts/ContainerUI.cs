using Items.Inventory.Scripts;
using Items.ItemContainer.Scripts;
using Items.Scripts;
using UnityEngine;

namespace Items.ItemContainer.UI.Scripts
{
    public class ContainerUI : MonoBehaviour
    {
        public GameObject containerUI; // The root UI GameObject
        public Transform playerItemsParent; // Parent object for player inventory slots
        public Transform containerItemsParent; // Parent object for container inventory slots

        public GameInventory playerInventory;
        public Container container;
        InventorySlot[] _containerSlots;

        InventorySlot[] _playerSlots;

        void Start()
        {
            if (containerUI == null)
                containerUI = gameObject;

            _playerSlots = playerItemsParent.GetComponentsInChildren<InventorySlot>();
            _containerSlots = containerItemsParent.GetComponentsInChildren<InventorySlot>();

            // Initially hide the container UI
            containerUI.SetActive(false);
        }

        public void Open(GameInventory playerInventory, Container container)
        {
            this.playerInventory = playerInventory;
            this.container = container;

            UpdateUI();

            // Show the container UI
            containerUI.SetActive(true);
        }

        public void Close()
        {
            containerUI.SetActive(false);
            // Clear references
            playerInventory = null;
            container = null;
        }

        void UpdateUI()
        {
            // Update player inventory slots
            for (var i = 0; i < _playerSlots.Length; i++)
                if (i < playerInventory.items.Count)
                    _playerSlots[i].AddItem(playerInventory.items[i]);
                else
                    _playerSlots[i].ClearSlot();

            // Update container inventory slots
            for (var i = 0; i < _containerSlots.Length; i++)
                if (i < container.GetItems().Count)
                    _containerSlots[i].AddItem(container.GetItems()[i]);
                else
                    _containerSlots[i].ClearSlot();
        }

        public void TransferItem(GameItem item, bool toContainer)
        {
            if (toContainer)
            {
                playerInventory.RemoveItem(item);
                container.inventory.AddItem(item);
            }
            else
            {
                container.inventory.RemoveItem(item);
                playerInventory.AddItem(item);
            }

            UpdateUI();
        }
    }
}
