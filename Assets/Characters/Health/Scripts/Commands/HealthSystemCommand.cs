using Core.Events.EventManagers;

namespace Characters.Health.Scripts.Commands
{
    public interface IHealthSystemCommand
    {
        void Execute(HealthSystem healthSystem, float value, ICharacterEventManager eventManager);
    }
}
