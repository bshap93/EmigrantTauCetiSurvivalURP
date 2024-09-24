using System.Collections;
using Characters.Player.Scripts;
using Characters.Scripts;
using Combat.Attacks.Commands;
using Combat.Weapons.Scripts;
using Combat.Weapons.Scripts.PlayerWeapons;
using Items.Equipment;
using Items.Scripts;
using UnityEngine;

namespace Combat.Weapons
{
    public class WeaponHandler : EquippableHandler
    {
        public Weapon currentWeapon;
        public LineRenderer lineRenderer;
        public Transform firePoint;

        public override void Equip(IEquippableItem item, IDamageable equipper)
        {
            if (item is Weapon weapon)
            {
                if (currentWeapon != null) currentWeapon.Unequip(currentWeapon, equipper); // Unequip the current weapon

                currentWeapon = weapon;
                currentWeapon.Equip(weapon, equipper); // Equip the new weapon


                if (equipper is PlayerCharacter character)
                {
                    if (weapon is LaserTool || weapon.GetAttackCommand() is RangedAttackCommand)
                    {
                        lineRenderer.enabled = true;
                        character.EnterCombatReadyState();
                    }
                    else
                    {
                        lineRenderer.enabled = false;
                        character.ReturnToExploreState();
                    }
                }

                // Handle transitioning into combat stance based on weapon type
                // if ((equipper is PlayerCharacter player && weapon is LaserTool) ||
                //     weapon.GetAttackCommand() is RangedAttackCommand)
                //     player.EnterCombatReadyState();
                // else
                //     player.ReturnToExploreState();
            }
        }
        public override void Unequip(IEquippableItem item, IDamageable equipper)
        {
            if (item is Weapon weapon && currentWeapon == weapon)
            {
                weapon.Unequip(weapon, equipper);
                currentWeapon = null;
                if (equipper is PlayerCharacter character)
                {
                    lineRenderer.enabled = false;
                    character.ReturnToExploreState();
                }
            }
        }


        public void PerformAttack(IDamageable target)
        {
            if (currentWeapon != null)
                // Pass the WeaponHandler to the weapon's attack method
                currentWeapon.Attack(target, this);
        }

        // Starts the laser effect coroutine
        public void StartLaserEffect(float duration)
        {
            StartCoroutine(LaserEffect(duration));
        }

        // Update the line renderer for the laser's position
        public void UpdateLaserEffect(Vector3 targetPosition)
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, targetPosition);
        }

        IEnumerator LaserEffect(float duration)
        {
            lineRenderer.enabled = true;
            yield return new WaitForSeconds(duration);
            lineRenderer.enabled = false;
        }
    }
}
