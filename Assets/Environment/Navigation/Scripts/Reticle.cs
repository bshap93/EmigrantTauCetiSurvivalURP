using DG.Tweening;
using UnityEngine;

namespace Environment.Navigation.Scripts
{
    public class Reticle : MonoBehaviour
    {
        public static Reticle Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Optional, to keep the reticle across scenes if needed
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetPosition(Vector3 targetPosition)
        {
            // Set the reticle's position directly without hardcoding
            transform.position = targetPosition;
        }

        public void StartRotation()
        {
            // Trigger the rotation, assuming the DoTweenAnimation component is attached
            // or use DOLocalRotate if you want it programmatically
            transform.DOLocalRotate(new Vector3(0, 360, 0), 2.0f, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart); // Continuous rotation
        }

        public void Show(Vector3 position)
        {
            SetPosition(position);
            gameObject.SetActive(true); // Show the reticle
            StartRotation(); // Start rotating it
        }

        public void Hide()
        {
            gameObject.SetActive(false); // Hide the reticle
        }
    }
}
