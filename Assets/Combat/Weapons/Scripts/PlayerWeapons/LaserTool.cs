using Characters.Scripts;
using Combat.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts.PlayerWeapons
{
    [CreateAssetMenu(menuName = "Weapons/LaserTool")]
    public class LaserTool : Weapon
    {
        public float laserRange = 10f;
        public float laserDuration = 0.1f;


        public override void InitializeAttackCommand(WeaponHandler weaponHandler)
        {
            AttackCommand = new RangedAttackCommand(this, laserRange, weaponHandler.firePoint);
        }
        public override void Attack(IDamageable target, WeaponHandler handler)
        {
            // Delegate the coroutine to the WeaponHandler
            handler.StartLaserEffect(laserDuration);

            // Perform raycast to handle the hit logic
            RaycastHit hit;
            if (Physics.Raycast(handler.firePoint.position, handler.firePoint.forward, out hit, laserRange))
            {
                var damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    Debug.Log($"Hit: {hit.transform.name}");
                    damageable.TakeDamage(damageable, damage);
                }

                // Update laser hit position
                handler.UpdateLaserEffect(hit.point);
            }
            else
            {
                // Laser reaches max range
                handler.UpdateLaserEffect(handler.firePoint.position + handler.firePoint.forward * laserRange);
            }
        }
    }
}
