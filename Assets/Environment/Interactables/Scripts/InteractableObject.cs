using Characters.Player.InputHandlers.Scripts;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Environment.Interactables.Scripts
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        public enum InteractableType
        {
            Container,
            Door,
            Display,
            Panel
        }

        [FormerlySerializedAs("InteractionUI")]
        public GameObject interactionUI;

        public bool broken;

        public string objectName;

        public GameObject tooltipPrefab;

        public InteractableType interactableType;
        Collider _zoneCollider;

        bool playerInRange;

        GameObject tooltipInstance;

        Canvas uiCanvas;

        void Start()
        {
            uiCanvas = UIManager.Instance.uiCanvas;

            if (uiCanvas == null)
            {
                Debug.LogError("UI Canvas not found in scene");
                return;
            }

            // Get the Collider from the child zone (assuming there's a single child collider)
            _zoneCollider = GetComponent<BoxCollider>();

            // Ensure it's marked as a trigger
            if (_zoneCollider != null)
                _zoneCollider.isTrigger = true;
        }

        void Update()
        {
            if (playerInRange)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    InteractSimple();
                    HideTooltip();
                }

                UpdateTooltipPosition();
            }
        }

        // Trigger detection for when the player enters the zone
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Notify the player they can interact with this object
                SimpleInteractInputHandler.Instance.SetInteractable(this);

                playerInRange = true;
                ShowTooltip();
            }
        }

        // Trigger detection for when the player exits the zone
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Clear the reference when the player leaves the range
                SimpleInteractInputHandler.Instance.ClearInteractable();
                EndInteractionSimple();
                playerInRange = false;
                HideTooltip();
            }
        }

        public void InteractSimple()
        {
            UIManager.Instance.inGameConsoleManager
                .LogMessage("Interacting with object: " + objectName);

            if (interactableType == InteractableType.Container) interactionUI.SetActive(true);
        }

        void ShowTooltip()
        {
            if (tooltipInstance == null && tooltipPrefab != null && uiCanvas != null)
            {
                // Instantiate the tooltip as a child of the Canvas
                tooltipInstance = Instantiate(tooltipPrefab, uiCanvas.transform);

                // Set the initial position of the tooltip
                UpdateTooltipPosition();
            }
        }

        void HideTooltip()
        {
            if (tooltipInstance != null)
            {
                Destroy(tooltipInstance);
                tooltipInstance = null;
            }
        }

        void UpdateTooltipPosition()
        {
            if (tooltipInstance != null)
            {
                // Convert the object's position to screen space
                var screenPosition = Camera.main.WorldToScreenPoint(transform.position);

                // Set the tooltip's position
                tooltipInstance.GetComponent<RectTransform>().position = screenPosition;
            }
        }

        public void EndInteractionSimple()
        {
            if (interactableType == InteractableType.Container)
            {
                interactionUI.SetActive(false);
                Debug.Log("End interaction with container");
            }
        }
    }
}
