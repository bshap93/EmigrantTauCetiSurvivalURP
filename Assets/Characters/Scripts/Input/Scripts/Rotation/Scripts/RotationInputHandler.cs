using Characters.Scripts.Commands.Rotate;
using UnityEngine;

namespace Characters.Scripts.Input.Scripts.Rotation.Scripts
{
    public class RotationInputHandler : MonoBehaviour
    {
        public GameObject player;
        public float timeToRotate = 0.5f;

        public Camera mainCamera;
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


        public void ExecuteRotateLeftCommand()
        {
            var cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0; // Ignore vertical direction
            var rotateLeft = new RotateCommand(-90f, cameraForward, timeToRotate);
            rotateLeft.Execute(player);
        }

        public void ExecuteRotateRightCommand()
        {
            var cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0; // Ignore vertical direction
            var rotateRight = new RotateCommand(90f, cameraForward, timeToRotate);
            rotateRight.Execute(player);
        }

        public void ExecuteRotateUpCommand()
        {
            var cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0; // Ignore vertical direction
            var rotateUp = new RotateCommand(0f, cameraForward, timeToRotate);
            rotateUp.Execute(player);
        }

        public void ExecuteRotateDownCommand()
        {
            var cameraForward = mainCamera.transform.forward;
            cameraForward.y = 0; // Ignore vertical direction
            var rotateDown = new RotateCommand(180f, cameraForward, timeToRotate);
            rotateDown.Execute(player);
        }
    }
}
