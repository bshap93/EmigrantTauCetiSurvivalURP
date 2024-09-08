using Cinemachine;
using Core.Cameras.Commands.RotateCamera;
using UnityEngine;

namespace Core.Cameras.InputHandlers
{
    // Camera controller for rotating the virtual camera
    public class BasicCameraMovementInputHandler : MonoBehaviour
    {
        // Reference to the Cinemachine Virtual Camera
        public CinemachineVirtualCamera virtualCamera; // Reference to the Cinemachine Virtual Camera
        // Reference to the player character to follow
        public Transform player;

        public float mouseInfluence = 2f; // How much the mouse affects camera movement
        public float maxMouseOffset = 3f; // Maximum allowed camera movement offset

        CinemachineCameraOffset _cameraOffset;
        Vector2 _currentMousePosition;

        Vector2 _initialMousePosition;
        // Current Y rotation of the virtual camera which is the initial Y rotation
        public float CurrentYRotation { get; private set; }
        // Initial X and Z rotations of the virtual camera
        public float InitialXRotation { get; private set; }
        public float InitialZRotation { get; private set; }


        void Start()
        {
            // Get the initial rotation of the virtual camera
            InitialXRotation = virtualCamera.transform.rotation.eulerAngles.x;
            InitialZRotation = virtualCamera.transform.rotation.eulerAngles.z;
            // Get the current Y rotation of the virtual camera is the initial Y rotation
            CurrentYRotation = virtualCamera.transform.rotation.eulerAngles.y;

            _cameraOffset = virtualCamera.GetComponent<CinemachineCameraOffset>();

            // Set the initial mouse position
            _initialMousePosition = Input.mousePosition;
            _currentMousePosition = _initialMousePosition;
        }

        void Update()
        {
            // Handle camera rotation
            HandleCameraRotation();
            HandleCameraMovement();
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

        // Handle camera movement based on user input
        void HandleCameraMovement()
        {
            // Get the mouse movement
            var mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            _currentMousePosition = Input.mousePosition;
            

            var xRelative = _currentMousePosition.x - _initialMousePosition.x;
            var yRelative = _currentMousePosition.y - _initialMousePosition.y;

            if (_currentMousePosition.x > _initialMousePosition.x)
            {
                if (_cameraOffset.m_Offset.x < maxMouseOffset)
                    _cameraOffset.m_Offset.x += xRelative * mouseInfluence * Time.deltaTime;
            }
            else if (_currentMousePosition.x < _initialMousePosition.x)
            {
                if (_cameraOffset.m_Offset.x > -maxMouseOffset)
                    _cameraOffset.m_Offset.x += xRelative * mouseInfluence * Time.deltaTime;
            }


            if (_currentMousePosition.y > _initialMousePosition.y)
            {
                if (_cameraOffset.m_Offset.y < maxMouseOffset)
                    _cameraOffset.m_Offset.y += yRelative * mouseInfluence * Time.deltaTime;
            }
            else if (_currentMousePosition.y < _initialMousePosition.y)
            {
                if (_cameraOffset.m_Offset.y > -maxMouseOffset)
                    _cameraOffset.m_Offset.y += yRelative * mouseInfluence * Time.deltaTime;
            }


            UnityEngine.Debug.Log(_currentMousePosition);
        }
    }
}
