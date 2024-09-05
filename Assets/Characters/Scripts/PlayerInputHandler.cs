using Characters.Scripts.Input.Scripts.Movement.Scripts;
using Characters.Scripts.Input.Scripts.Rotation.Scripts;
using UnityEngine;

namespace Characters.Scripts
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] MovementInputHandler movementInputHandler;
        [SerializeField] RotationInputHandler rotationInputHandler;


        void Start()
        {
            if (movementInputHandler == null) movementInputHandler = MovementInputHandler.Instance;

            if (rotationInputHandler == null) rotationInputHandler = RotationInputHandler.Instance;
        }

        void Update()
        {
            HandleInput();
        }

        void HandleInput()
        {
            // Handle player input for movement
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                movementInputHandler.ExecuteMoveUpCommand();
                rotationInputHandler.ExecuteRotateUpCommand();
            }

            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                movementInputHandler.ExecuteMoveDownCommand();
                rotationInputHandler.ExecuteRotateDownCommand();
            }

            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                movementInputHandler.ExecuteMoveLeftCommand();
                rotationInputHandler.ExecuteRotateLeftCommand();
            }


            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                movementInputHandler.ExecuteMoveRightCommand();
                rotationInputHandler.ExecuteRotateRightCommand();
            }
        }
    }
}
