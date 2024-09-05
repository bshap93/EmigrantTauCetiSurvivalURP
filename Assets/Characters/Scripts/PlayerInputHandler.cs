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
                rotationInputHandler.RotateToAbsoluteAngle(180);
            }

            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                movementInputHandler.ExecuteMoveDownCommand();
                rotationInputHandler.RotateToAbsoluteAngle(0);
            }

            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                movementInputHandler.ExecuteMoveLeftCommand();
                rotationInputHandler.RotateToAbsoluteAngle(90);
            }

            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                movementInputHandler.ExecuteMoveRightCommand();
                rotationInputHandler.RotateToAbsoluteAngle(-90);
            }
        }
    }
}
