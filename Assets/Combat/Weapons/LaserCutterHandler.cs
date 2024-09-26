using Characters.Scripts;

namespace Combat.Weapons
{
    public class LaserCutterHandler : WeaponHandler
    {
        public override void Use(IDamageable target)
        {
            FireLaserCutter();
        }

        void FireLaserCutter()
        {
            // Fire the laser cutter
        }
    }
}
