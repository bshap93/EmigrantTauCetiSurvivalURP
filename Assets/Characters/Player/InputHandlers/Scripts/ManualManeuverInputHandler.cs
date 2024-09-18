using Characters.InputHandlers.Scripts;
using Characters.Player.Scripts.Movement;
using Core.InputHandler.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Characters.Player.InputHandlers.Scripts
{
    public class ManualManeuverInputHandler : MonoBehaviour, IInputHandler
    {
        [SerializeField] MovementManager movementManager;
        [FormerlySerializedAs("playerRotationInputHandler")] [SerializeField]
        RotatePlayerDirection rotatePlayerDirection;


        void Start()
        {
            if (movementManager == null) movementManager = MovementManager.Instance;
        }

        void Update()
        {
            HandleInput();
        }

        public void HandleInput()
        {
            if (Input.GetMouseButton(1)) Debug.Log("Player is in Firing stance");
            // Handle player input for movement
            if (Input.GetKey(KeyCode.W))
            {
                movementManager.ExecuteMoveUpCommand();
                rotatePlayerDirection.ExecuteRotateUpCommand();
            }

            if (Input.GetKey(KeyCode.S))
            {
                movementManager.ExecuteMoveDownCommand();
                rotatePlayerDirection.ExecuteRotateDownCommand();
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementManager.ExecuteMoveLeftCommand();
                rotatePlayerDirection.ExecuteRotateLeftCommand();
            }


            if (Input.GetKey(KeyCode.D))
            {
                movementManager.ExecuteMoveRightCommand();
                rotatePlayerDirection.ExecuteRotateRightCommand();
            }
        }
    }
}
