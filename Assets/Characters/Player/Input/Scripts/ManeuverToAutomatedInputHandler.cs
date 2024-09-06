using Characters.Scripts.Commands.Move;
using UnityEngine;

namespace Characters.Player.Input.Scripts
{
    public class ManeuverToAutomatedInputHandler : MonoBehaviour
    {
        public float speed = 5f;
        [SerializeField] GameObject playerGameObject;
        UnityEngine.Camera _camera;
        MoveToCommand _moveToCommand;

        void Start()
        {
            _camera = UnityEngine.Camera.main;
        }
        void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
                if (_camera != null)
                {
                    var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
                    if (Physics.Raycast(ray, out var hit))
                    {
                        _moveToCommand = new MoveToCommand(hit.point, speed); // Create MoveCommand
                        _moveToCommand.Execute(playerGameObject); // Execute the MoveCommand for the player
                    }
                }
        }
    }
}
