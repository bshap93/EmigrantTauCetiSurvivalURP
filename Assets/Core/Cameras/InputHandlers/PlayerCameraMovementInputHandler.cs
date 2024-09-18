using Cinemachine;
using Core.Cameras.Commands;
using Core.Cameras.Commands.MoveCamera;
using Core.Cameras.Commands.RotateCamera;
using Core.Cameras.Commands.ZoomCamera;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Cameras.InputHandlers
{
    public class PlayerCameraMovementInputHandler : MonoBehaviour
    {
        public CinemachineVirtualCamera virtualCamera;
        public Transform player;

        public float mouseInfluence = 2f;
        public float maxMouseOffset = 3f;
        public float deadZoneRadius = 50f;
        public float rotateYAmount = 15f;
        public float mouseSensitivity = 100f;
        public bool invertYAxisRotation;
        [FormerlySerializedAs("_isCameraLocked")] [SerializeField]
        bool isCameraLocked;

        Vector2 _initialMousePosition;

        public float CurrentYRotation { get; private set; }
        public float InitialXRotation { get; private set; }
        public float InitialZRotation { get; private set; }

        void Start()
        {
            InitialXRotation = virtualCamera.transform.rotation.eulerAngles.x;
            InitialZRotation = virtualCamera.transform.rotation.eulerAngles.z;
            CurrentYRotation = virtualCamera.transform.rotation.eulerAngles.y;


            var screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            _initialMousePosition = screenCenter;
        }

        void Update()
        {
            HandleCameraRotation();
            HandleCameraMovement();
            HandleCameraZoom();
        }

        void HandleCameraRotation()
        {
            ICameraCommand rotateCommand = null;

            if (Input.GetKey(KeyCode.E))
                rotateCommand = new RotateClockwiseCommand();
            else if (Input.GetKey(KeyCode.Q)) rotateCommand = new RotateCounterClockwiseCommand();

            if (Input.GetMouseButton(1)) // Right-click to rotate
            {
                var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

                if (mouseX > 0)
                    rotateCommand = new RotateClockwiseCommand();
                else if (mouseX < 0) rotateCommand = new RotateCounterClockwiseCommand();
            }

            rotateCommand?.Execute(virtualCamera, rotateYAmount);
        }

        void HandleCameraMovement()
        {
            if (!isCameraLocked)
            {
                Vector2 currentMousePosition = Input.mousePosition;
                var mouseMovement = currentMousePosition - _initialMousePosition;

                var moveCommand = new MouseCameraMovementCommand(
                    mouseMovement, mouseInfluence, maxMouseOffset, deadZoneRadius);

                moveCommand.Execute(virtualCamera, 0);
            }
        }

        void HandleCameraZoom()
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                var zoomCommand = new ZoomCommand();
                zoomCommand.Execute(virtualCamera, 0.5f);
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                var zoomCommand = new ZoomCommand();
                zoomCommand.Execute(virtualCamera, -0.5f);
            }
        }
    }
}
