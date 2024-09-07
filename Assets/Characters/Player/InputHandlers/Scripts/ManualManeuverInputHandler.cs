using Characters.Player.InputHandlers.Scripts;
using Characters.Scripts.Input.Scripts.Movement.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Characters.Player.Input.Scripts
{
    public class ManualManeuverInputHandler : MonoBehaviour
    {
        [SerializeField] MovementInputHandler movementInputHandler;
        [FormerlySerializedAs("rotationInputHandler")] [SerializeField]
        PlayerRotationInputHandler playerRotationInputHandler;


        void Start()
        {
            if (movementInputHandler == null) movementInputHandler = MovementInputHandler.Instance;

            if (playerRotationInputHandler == null) playerRotationInputHandler = PlayerRotationInputHandler.Instance;
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
                playerRotationInputHandler.ExecuteRotateUpCommand();
            }

            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                movementInputHandler.ExecuteMoveDownCommand();
                playerRotationInputHandler.ExecuteRotateDownCommand();
            }

            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                movementInputHandler.ExecuteMoveLeftCommand();
                playerRotationInputHandler.ExecuteRotateLeftCommand();
            }


            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                movementInputHandler.ExecuteMoveRightCommand();
                playerRotationInputHandler.ExecuteRotateRightCommand();
            }
        }
    }
}
