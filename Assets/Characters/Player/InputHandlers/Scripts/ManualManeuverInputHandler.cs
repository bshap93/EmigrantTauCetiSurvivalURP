using Characters.InputHandlers.Scripts;
using Characters.Player.Scripts;
using Characters.Player.Scripts.Movement;
using Characters.Player.Scripts.States;
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
        [SerializeField] PlayerCharacter playerCharacter;


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
            HandleMovementInput();
            HandleCombatInput();
        }

        void HandleMovementInput()
        {
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

        void HandleCombatInput()
        {
            if (Input.GetMouseButton(1))
            {
                playerCharacter.ChangeState(new CombatReadyState(playerCharacter.GetCurrentState(), null));

                if (Input.GetMouseButton(0))
                    Debug.Log("Player is attacking");
            }
        }
    }
}
