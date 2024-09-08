namespace Core.Systems.Scripts
{
    public abstract class SystemBase
    {
        public bool IsActive { get; private set; }

        public void Activate()
        {
            if (IsActive) return;

            OnActivate();
            IsActive = true;
        }

        public void Deactivate()
        {
            if (!IsActive) return;

            OnDeactivate();
            IsActive = false;
        }

        protected abstract void OnActivate();
        protected abstract void OnDeactivate();
    }
}
