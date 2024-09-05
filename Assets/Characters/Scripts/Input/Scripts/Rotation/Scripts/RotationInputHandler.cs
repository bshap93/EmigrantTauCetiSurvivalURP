using Characters.Scripts.Commands.Rotate;
using UnityEngine;

namespace Characters.Scripts.Input.Scripts.Rotation.Scripts
{
    public class RotationInputHandler : MonoBehaviour
    {
        // Reference to the player object
        public GameObject player;
        // Reference to the main camera
        public Camera mainCamera;

        // Character controller replaces the rigidbody for movement
        public CharacterController controller;

        public float rotationSpeed = 10f;

        RotateCommand _rotateCommand;

        public static RotationInputHandler Instance { get; private set; }

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

        void Start()
        {
            _rotateCommand = new RotateCommand(Vector3.zero);
        }

        void Update()
        {
        }


        // Method to rotate by a relative Y angle (current behavior)
        public void RotateByRelativeAngle(float angle)
        {
            var currentRotation = player.transform.eulerAngles;
            var newRotationY = currentRotation.y + angle;

            // Apply the new rotation
            player.transform.eulerAngles = new Vector3(currentRotation.x, newRotationY, currentRotation.z);
        }

        // Method to rotate to an absolute Y angle
        public void RotateToAbsoluteAngle(float targetY)
        {
            var currentRotation = player.transform.eulerAngles;

            // Set rotation directly to the target Y angle
            player.transform.eulerAngles = new Vector3(currentRotation.x, targetY, currentRotation.z);

            Debug.Log("Rotated to absolute Y angle: " + targetY);
        }
    }
}
