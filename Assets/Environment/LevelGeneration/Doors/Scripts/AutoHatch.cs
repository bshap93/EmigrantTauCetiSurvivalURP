using DunGen;
using Environment.LevelGeneration.Doors.Scripts.Commands.OpenClose;
using LevelGeneration.Tiles.Doors.Scripts;
using UnityEngine;
using UnityEngine.AI;

namespace Environment.LevelGeneration.Doors.Scripts
{
    public class AutoHatch : MonoBehaviour
    {
        public enum DoorState
        {
            Open,
            Closed,
            Opening,
            Closing
        }


        public float speed = 3.0f;
        public GameObject hatchRightHalf;
        public GameObject hatchLeftHalf;

        public Vector3 hatchRightOpenOffset = new(-2.5f, 0f, 0);
        public Vector3 hatchLeftOpenOffset = new(2.5f, 0f, 0);
        IDoorCommand _closeCommand;

        float _currentFramePosition;
        DoorState _currentState = DoorState.Closed;
        Door _doorComponent;
        Vector3 _hatchLeftClosedPosition;
        Vector3 _hatchRightClosedPosition;
        NavMeshObstacle _navMeshObstacle;

        IDoorCommand _openCommand;

        // Start is called before the first frame update
        void Start()
        {
            _doorComponent = GetComponent<Door>();
            _hatchLeftClosedPosition = hatchLeftHalf.transform.localPosition;
            _hatchRightClosedPosition = hatchRightHalf.transform.localPosition;
            _navMeshObstacle = GetComponent<NavMeshObstacle>();

            _navMeshObstacle.carving = true;

            _openCommand = new OpenHatchCommand(this, _navMeshObstacle);
            _closeCommand = new CloseHatchCommand(this, _navMeshObstacle);
        }

        // Update is called once per frame
        void Update()
        {
            if (_currentState == DoorState.Opening || _currentState == DoorState.Closing) MoveHatch();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var playerController = other.GetComponent<CharacterController>();
                if (playerController == null) return;

                _openCommand.Execute();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var playerController = other.GetComponent<CharacterController>();
                if (playerController == null) return;

                _closeCommand.Execute();
            }
        }

        void MoveHatch()
        {
            var hatchLeftOpenPosition = _hatchLeftClosedPosition + hatchLeftOpenOffset;
            var hatchRightOpenPosition = _hatchRightClosedPosition + hatchRightOpenOffset;

            var frameOffset = speed * Time.deltaTime;
            if (_currentState == DoorState.Closing)
                frameOffset *= -1;

            _currentFramePosition += frameOffset;
            _currentFramePosition = Mathf.Clamp(_currentFramePosition, 0, 1);

            hatchLeftHalf.transform.localPosition = Vector3.Lerp(
                _hatchLeftClosedPosition, hatchLeftOpenPosition, _currentFramePosition);

            hatchRightHalf.transform.localPosition = Vector3.Lerp(
                _hatchRightClosedPosition, hatchRightOpenPosition, _currentFramePosition);

            // Update state when finished
            if (Mathf.Approximately(_currentFramePosition, 1.0f))
            {
                _currentState = DoorState.Open;
            }
            else if (Mathf.Approximately(_currentFramePosition, 0))
            {
                _currentState = DoorState.Closed;
                _doorComponent.IsOpen = false;
            }
        }

        public void SetState(DoorState newState)
        {
            _currentState = newState;
            if (newState == DoorState.Opening) _doorComponent.IsOpen = true;
        }
    }
}
