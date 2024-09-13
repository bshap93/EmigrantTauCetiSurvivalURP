using Environment.Interactables.Chests.Scripts.Commands;
using Environment.Interactables.Openable.Scripts;
using UnityEngine;

namespace Environment.Interactables.Chests.Scripts
{
    public class OpenableChest : OpenableObject
    {
        public enum ChestState
        {
            Open,
            Closed,
            Opening,
            Closing
        }

        public GameObject chestLid;
        public GameObject chestBase;

        public Vector3 chestLidOpenPositionOffset = new(0, 0.5f, 0);
        public Vector3 chestLidOpenRotationOffset = new(0, 0, 0);
        Vector3 _chestLidClosedPosition;
        Vector3 _chestLidClosedRotation;


        void Start()
        {
            _chestLidClosedPosition = chestLid.transform.localPosition;
            _chestLidClosedRotation = chestLid.transform.localEulerAngles;
            CurrentState = OpenableState.Closed;
            OpenCommand = new OpenChestCommand(this);
            CloseCommand = new CloseChestCommand(this);
        }

        // Update is called once per frame
        void Update()
        {
            if (CurrentState == OpenableState.Opening || CurrentState == OpenableState.Closing) MoveObject();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var playerController = other.GetComponent<CharacterController>();
                if (playerController == null) return;

                Debug.Log("Player entered chest trigger");

                OpenCommand.Execute();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var playerController = other.GetComponent<CharacterController>();
                if (playerController == null) return;

                CloseCommand.Execute();
            }
        }

        public override void MoveObject()
        {
            var chestLidOpenPosition = _chestLidClosedPosition + chestLidOpenPositionOffset;
            var chestLidOpenRotation = _chestLidClosedRotation + chestLidOpenRotationOffset;

            var frameOffset = speed * Time.deltaTime;
            if (CurrentState == OpenableState.Closing)
                frameOffset *= -1;

            CurrentFramePosition += frameOffset;
            CurrentFramePosition = Mathf.Clamp(CurrentFramePosition, 0, 1);

            chestLid.transform.localPosition = Vector3.Lerp(
                _chestLidClosedPosition, chestLidOpenPosition, CurrentFramePosition);

            chestLid.transform.localRotation = Quaternion.Lerp(
                Quaternion.Euler(_chestLidClosedRotation), Quaternion.Euler(chestLidOpenRotation),
                CurrentFramePosition);


            // Update state when finished
            if (Mathf.Approximately(CurrentFramePosition, 1.0f))
                CurrentState = OpenableState.Open;
            else if (Mathf.Approximately(CurrentFramePosition, 0)) CurrentState = OpenableState.Closed;
        }
        public override void SetState(OpenableState newState)
        {
            CurrentState = newState;
        }
    }
}
