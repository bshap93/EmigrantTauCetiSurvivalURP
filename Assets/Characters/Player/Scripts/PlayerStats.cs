using Characters.Health.Scripts;
using UnityEngine;

namespace Characters.Player.Scripts
{
    public class PlayerStats : MonoBehaviour
    {
        public PlayerCharacter player;
        public HealthSystem HealthSystem;

        void Start()
        {
            HealthSystem = new HealthSystem("Player", 100, player.playerEventManager);
        }
        public void Heal(float value)
        {
            HealthSystem.Heal(value);
        }
    }
}
