using Cinemachine;
using Core.Cameras.Commands;
using Core.Cameras.Commands.MoveCamera;
using Core.Cameras.Commands.RotateCamera;
using UnityEngine;

namespace Core.Cameras.InputHandlers
{
    public class BasicCameraMovementInputHandler : MonoBehaviour
    {
        public CinemachineVirtualCamera virtualCamera;
        public Transform player;

        public float mouseInfluence = 2f;
        public float maxMouseOffset = 3f;
        public float deadZoneRadius = 50f;

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
        }

        void HandleCameraRotation()
        {
            ICameraCommand rotateCommand = null;

            if (Input.GetKeyDown(KeyCode.Q))
                rotateCommand = new RotateClockwiseCommand();
            else if (Input.GetKeyDown(KeyCode.E)) rotateCommand = new RotateCounterClockwiseCommand();

            rotateCommand?.Execute(virtualCamera);
        }

        void HandleCameraMovement()
        {
            Vector2 currentMousePosition = Input.mousePosition;
            var mouseMovement = currentMousePosition - _initialMousePosition;

            var moveCommand = new MouseCameraMovementCommand(
                mouseMovement, mouseInfluence, maxMouseOffset, deadZoneRadius);

            moveCommand.Execute(virtualCamera);
        }
    }
}
