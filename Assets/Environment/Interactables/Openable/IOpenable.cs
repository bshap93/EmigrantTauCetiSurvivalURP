using Environment.Interactables.Openable.Scripts;

namespace Environment.Interactables.Openable
{
    public interface IOpenable
    {
        void MoveObject();

        public void SetState(OpenableObject.OpenableState state);
    }
}
