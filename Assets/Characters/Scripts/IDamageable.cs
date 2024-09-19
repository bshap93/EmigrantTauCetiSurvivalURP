using Characters.Health.Scripts;

namespace Characters.Scripts
{
    public interface IDamageable
    {
        void TakeDamage(IDamageable dmgeable, float damage);
        HealthSystem GetHealthSystem();
    }
}
