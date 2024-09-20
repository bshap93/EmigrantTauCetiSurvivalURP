using Items.ItemContainer.UI.Scripts;
using Items.Scripts;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Items.Inventory.Scripts
{
    public class InventorySlot : MonoBehaviour
    {
        public Image icon;
        public Button transferButton;
        ContainerUI _containerUI;
        bool _isPlayerInventory;

        GameItem _item;

        void Start()
        {
            _containerUI = UIManager.Instance.containerUI;
        }

        public void AddItem(GameItem newItem)
        {
            _item = newItem;
            icon.sprite = _item.icon;
            icon.enabled = true;
            transferButton.interactable = true;
        }

        public void ClearSlot()
        {
            _item = null;
            icon.sprite = null;
            icon.enabled = false;
            transferButton.interactable = false;
        }

        public void OnTransferButton()
        {
            _containerUI.TransferItem(_item, !_isPlayerInventory);
        }

        public void SetIsPlayerInventory(bool isPlayerInventory)
        {
            _isPlayerInventory = isPlayerInventory;
        }
    }
}
