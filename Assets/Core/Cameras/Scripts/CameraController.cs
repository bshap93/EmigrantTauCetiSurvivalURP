using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Core.Cameras.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine Virtual Camera
        public Transform player; // The player character to follow
        float _currentYRotation; // Current Y position of the virtual camera
        float _initialXRotation; // Initial X rotation of the virtual camera
        float _initialZRotation; // Initial Z rotation of the virtual camera

        void Start()
        {
            // Get the initial rotation of the virtual camera
            _initialXRotation = virtualCamera.transform.rotation.eulerAngles.x;
            _initialZRotation = virtualCamera.transform.rotation.eulerAngles.z;
            _currentYRotation = virtualCamera.transform.rotation.eulerAngles.y;
        }

        void Update()
        {
            HandleCameraRotation();
        }

        void HandleCameraRotation()
        {
            // Rotate left (Q)
            if (UnityEngine.Input.GetKeyDown(KeyCode.Q))
            {
                _currentYRotation += 90f;
                RotateCamera();
            }
            // Rotate right (E)
            else if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                _currentYRotation -= 90f;
                RotateCamera();
            }
        }

        void RotateCamera()
        {
            virtualCamera.transform.DORotate(
                new Vector3(_initialXRotation, _currentYRotation, _initialZRotation), 0.5f);
        }
    }
}
