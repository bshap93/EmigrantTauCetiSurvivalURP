using Items.Inventory.Scripts;
using UI;
using UnityEngine;

namespace Items.ItemContainer.Scripts
{
    public class ContainerInteraction : MonoBehaviour
    {
        Container _container;

        void Start()
        {
            _container = GetComponent<Container>();
        }

        void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
                // Check for interaction input (e.g., pressing the 'E' key)
                if (Input.GetKeyDown(KeyCode.E))
                    OpenContainer(other.gameObject);
        }
        void OpenContainer(GameObject player)
        {
            var playerInventory = player.GetComponent<GameInventory>();

            if (playerInventory != null)
            {
                var containerUI = UIManager.Instance.containerUI;
                containerUI.Open(playerInventory, _container);
            }
        }
    }
}
