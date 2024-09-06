using Characters.Scripts.Commands.Move;
using UnityEngine;

namespace Characters.Player.Input.Scripts
{
    public class ManeuverToAutomatedInputHandler : MonoBehaviour
    {
        public float speed = 5f;
        [SerializeField] CharacterController controller;
        Camera _camera;
        MoveToCommand _moveToCommand;

        void Start()
        {
            _camera = Camera.main;
        }
        void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
                if (_camera != null)
                {
                    var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
                    if (Physics.Raycast(ray, out var hit))
                    {
                        _moveToCommand = new MoveToCommand(hit.point, speed, controller); // Create MoveCommand
                        _moveToCommand.Execute(gameObject); // Execute the MoveCommand for the player
                    }
                }
        }
    }
}
