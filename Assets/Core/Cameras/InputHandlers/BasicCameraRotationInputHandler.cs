using Cinemachine;
using Core.Cameras.Commands.RotateCamera;
using UnityEngine;

namespace Core.Cameras.InputHandlers
{
    // Camera controller for rotating the virtual camera
    public class BasicCameraRotationInputHandler : MonoBehaviour
    {
        // Reference to the Cinemachine Virtual Camera
        public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine Virtual Camera
        // Reference to the player character to follow
        public Transform player; // The player character to follow
        // Current Y rotation of the virtual camera which is the initial Y rotation
        float _currentYRotation; // Current Y position of the virtual camera
        // Initial X and Z rotations of the virtual camera
        float _initialXRotation; // Initial X rotation of the virtual camera
        float _initialZRotation; // Initial Z rotation of the virtual camera

        void Start()
        {
            // Get the initial rotation of the virtual camera
            _initialXRotation = virtualCamera.transform.rotation.eulerAngles.x;
            _initialZRotation = virtualCamera.transform.rotation.eulerAngles.z;
            // Get the current Y rotation of the virtual camera is the initial Y rotation
            _currentYRotation = virtualCamera.transform.rotation.eulerAngles.y;
        }

        void Update()
        {
            // Handle camera rotation
            HandleCameraRotation();
        }

        // Handle camera rotation based on user input
        void HandleCameraRotation()
        {
            // Rotate left (Q)
            if (Input.GetKeyDown(KeyCode.Q))
            {
                var rotateClockwise = new RotateClockwiseCommand();
                // Rotate the camera by 90 degrees to the left
                rotateClockwise.Execute(virtualCamera);
            }
            // Rotate right (E)
            else if (Input.GetKeyDown(KeyCode.E))
            {
                var rotateCounterClockwise = new RotateCounterClockwiseCommand();
                // Rotate the camera by 90 degrees to the right
                rotateCounterClockwise.Execute(virtualCamera);
            }
        }
    }
}
