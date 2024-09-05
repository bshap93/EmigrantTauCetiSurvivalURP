using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Core.Cameras.Scripts
{
    // Camera controller for rotating the virtual camera
    public class CameraController : MonoBehaviour
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
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                // Rotate the camera by 90 degrees to the left
                _currentYRotation += 90f;
                RotateCamera();
            }
            // Rotate right (E)
            else if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                // Rotate the camera by 90 degrees to the right
                _currentYRotation -= 90f;
                RotateCamera();
            }
        }

        // Rotate the virtual camera to the new rotation
        void RotateCamera()
        {
            // Rotate the virtual camera to the new rotation over 0.5 seconds using DOTween
            virtualCamera.transform.DORotate(
                new Vector3(_initialXRotation, _currentYRotation, _initialZRotation), 0.5f);
        }
    }
}
