namespace Characters.Health.Scripts.Commands
{
    public interface IHealthSystemCommand
    {
        void Execute(HealthSystem healthSystem, float value);
    }
}
