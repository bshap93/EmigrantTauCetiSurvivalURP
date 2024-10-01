using Characters.Health.Scripts.States;

namespace Characters.Scripts
{
    public interface IDamageable
    {
        void TakeDamage(IDamageable dmgeable, float damage);
        HealthSystem GetHealthSystem();
        void Heal(float value);
    }
}
