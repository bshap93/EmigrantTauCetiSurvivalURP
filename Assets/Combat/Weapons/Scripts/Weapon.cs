using Characters.Enemies;
using Characters.Enemies.Attacks.Commands;
using UnityEngine;

namespace Combat.Weapons.Scripts
{
    public abstract class Weapon : MonoBehaviour
    {
        protected IAttackCommand attackCommand;

        public abstract void Attack(Enemy target); // Implemented by subclasses
    }
}
