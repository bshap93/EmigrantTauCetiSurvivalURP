using Characters.InputHandlers.Scripts;
using Characters.Player.Scripts;
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
        [SerializeField] PlayerCharacter playerCharacter;


        void Start()
        {
            if (movementManager == null) movementManager = MovementManager.Instance;
            if (playerCharacter == null) playerCharacter = PlayerCharacter.Instance;
            if (rotatePlayerDirection == null)
                rotatePlayerDirection = playerCharacter.GetComponent<RotatePlayerDirection>();
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
            if (Input.GetMouseButton(1) && Input.GetMouseButton(0))
                playerCharacter.PerformAttack(null);
            else if (Input.GetMouseButtonUp(0)) playerCharacter.CeaseUsing();
            else if (Input.GetMouseButton(1))
                playerCharacter.EnterCombatReadyState();

            else
                playerCharacter.ReturnToExploreState();
        }
    }
}
