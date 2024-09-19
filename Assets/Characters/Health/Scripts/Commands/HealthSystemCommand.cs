using Characters.Scripts;
using Core.Events.EventManagers;

namespace Characters.Health.Scripts.Commands
{
    public interface IHealthSystemCommand
    {
        void Execute(IDamageable damageable, float value, ICharacterEventManager eventManager);
    }
}
