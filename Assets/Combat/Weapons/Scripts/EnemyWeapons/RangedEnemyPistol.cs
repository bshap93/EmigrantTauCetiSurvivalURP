using System.Collections.Generic;
using Characters.Enemies;
using Characters.Scripts;
using Combat.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts.EnemyWeapons
{
    public class RangedEnemyPistol : Weapon
    {
        public LineRenderer lineRenderer; // Optional, for visualizing the laser or projectile
        public Transform firePoint;
        public float laserRange = 10f;
        public float laserDuration = 0.1f;

        void Start()
        {
            damage = 10f; // Set damage for enemy weapon
            range = laserRange;
            AttackCommand = new RangedAttackCommand(this, range, firePoint); // Reuse the RangedAttackCommand
        }
        public override void Attack(Enemy target)
        {
            FireRangedEnemyPistol();
        }

        void FireRangedEnemyPistol()
        {
            StartCoroutine(LaserEffect());

            RaycastHit hit;
            if (Physics.Raycast(
                    firePoint.position,
                    firePoint.forward, out hit, laserRange,
                    ~0, QueryTriggerInteraction.Ignore))
            {
                var damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                    damageable.TakeDamage(damageable, damage);

                // Set the Line Renderer positions (from the fire point to the hit point)
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                // If the laser doesn't hit anything, set the line to max range
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * laserRange);
            }
        }

        IEnumerator<WaitForSeconds> LaserEffect()
        {
            lineRenderer.enabled = true;
            yield return new WaitForSeconds(laserDuration);
            lineRenderer.enabled = false;
        }
    }
}
