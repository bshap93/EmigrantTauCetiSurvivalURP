using Core.Utilities.Commands;
using UnityEngine;

namespace Environment.Interactables.Openable.Scripts
{
    public abstract class OpenableObject : MonoBehaviour, IOpenable
    {
        public enum OpenableState
        {
            Open,
            Closed,
            Opening,
            Closing
        }


        public float speed = 3.0f;


        Vector3[] _closedPositionsPerPart;

        float _currentFramePosition;
        OpenableState _currentState;
        protected ISimpleCommand CloseCommand;
        protected ISimpleCommand OpenCommand;


        // Update is called once per frame
        void Update()
        {
            if (_currentState == OpenableState.Opening || _currentState == OpenableState.Closing) MoveObject();
        }


        public abstract void SetState(OpenableState newState);

        public abstract void MoveObject();
    }
}
