using Characters.InputHandlers.Scripts;
using Core.InputHandler.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Characters.Player.InputHandlers.Scripts
{
    public class ManualManeuverInputHandler : MonoBehaviour, IInputHandler
    {
        [FormerlySerializedAs("movementInputHandler")] [SerializeField]
        MovementManager movementManager;
        [FormerlySerializedAs("rotationInputHandler")] [SerializeField]
        PlayerRotationInputHandler playerRotationInputHandler;


        void Start()
        {
            if (movementManager == null) movementManager = MovementManager.Instance;

            if (playerRotationInputHandler == null) playerRotationInputHandler = PlayerRotationInputHandler.Instance;
        }

        void Update()
        {
            HandleInput();
        }

        public void HandleInput()
        {
            // Handle player input for movement
            if (Input.GetKey(KeyCode.W))
            {
                movementManager.ExecuteMoveUpCommand();
                playerRotationInputHandler.ExecuteRotateUpCommand();
            }

            if (Input.GetKey(KeyCode.S))
            {
                movementManager.ExecuteMoveDownCommand();
                playerRotationInputHandler.ExecuteRotateDownCommand();
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementManager.ExecuteMoveLeftCommand();
                playerRotationInputHandler.ExecuteRotateLeftCommand();
            }


            if (Input.GetKey(KeyCode.D))
            {
                movementManager.ExecuteMoveRightCommand();
                playerRotationInputHandler.ExecuteRotateRightCommand();
            }
        }
    }
}
