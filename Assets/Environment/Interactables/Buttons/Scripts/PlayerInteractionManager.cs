using Environment.Interactables.Scripts;
using Environment.Navigation.Scripts;
using UnityEngine;

namespace Environment.Interactables.Buttons.Scripts
{
    public class PlayerInteractionManager : MonoBehaviour
    {
        public static PlayerInteractionManager Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void ShowReticleAtInteraction(InteractableObject interactable)
        {
            // Get the position of the interactable object (or wherever you want the reticle)
            var interactionPosition = interactable.transform.position;

            // Show the reticle at this position
            Reticle.Instance.Show(interactionPosition);
        }

        public void HideReticle()
        {
            // Hide the reticle when the player leaves
            Reticle.Instance.Hide();
        }
    }
}
