using System;
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

        OpenableState _currentState = OpenableState.Closed;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var playerController = other.GetComponent<CharacterController>();
                if (playerController == null) return;

                OpenCommand.Execute();
            }
        }

        void OnTriggerExit(Collider other)
        {
            throw new NotImplementedException();
        }

        public override void MoveObject()
        {
            var chestLidOpenPosition = chestBase.transform.position + new Vector3(0, 0.5f, 0);
        }
        public override void SetState(OpenableState newState)
        {
            _currentState = newState;
        }
    }
}
