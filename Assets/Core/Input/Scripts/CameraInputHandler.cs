using Characters.Player.Scripts.Commands;
using UnityEngine;

namespace Core.Input.Scripts
{
    public class InputHandler : MonoBehaviour
    {
        public GameObject player;
        public Camera mainCamera;
        MoveCommand _moveDownCommand;
        MoveCommand _moveLeftCommand;
        MoveCommand _moveRightCommand;

        MoveCommand _moveUpCommand;

        void Start()
        {
            // Initialize movement commands with the camera's transform
            _moveUpCommand = new MoveForwardCommand(mainCamera.transform);
            _moveDownCommand = new MoveForwardCommand(mainCamera.transform);
            _moveLeftCommand = new MoveLeftCommand(mainCamera.transform);
            _moveRightCommand = new MoveRightCommand(mainCamera.transform);
        }

        void Update()
        {
            HandleInput();
        }

        void HandleInput()
        {
            if (UnityEngine.Input.GetKey(KeyCode.W))
                _moveUpCommand.Execute(player);
            else if (UnityEngine.Input.GetKey(KeyCode.S))
                _moveDownCommand.Execute(player);
            else if (UnityEngine.Input.GetKey(KeyCode.A))
                _moveLeftCommand.Execute(player);
            else if (UnityEngine.Input.GetKey(KeyCode.D)) _moveRightCommand.Execute(player);
        }
    }
}
