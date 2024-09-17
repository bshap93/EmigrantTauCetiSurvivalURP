using Characters.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events
{
    public class EventManager : MonoBehaviour
    {
        // Pausing the game loop and entering a pause state overlay
        public static readonly UnityEvent EPauseGame = new();
        // Resuming the game loop and exiting the pause state overlay
        public static readonly UnityEvent EResumeGame = new();
        // Character has died, enter a game over state overlay
        public static readonly UnityEvent<string> ENotifyCharacterDied = new();
        // Health has changed for a character by a certain amount
        public static readonly UnityEvent<float> EChangeHealth = new();
        // Damage has been dealt to a character by name by a certain amount
        public static readonly UnityEvent<IDamageable, float> EDealDamage = new();

        public static readonly UnityEvent ERestartCurrentLevel = new();


        public static readonly UnityEvent EOnRoomGeneration = new();

        public static readonly UnityEvent EPlayerStateInitialized = new();

        public static readonly UnityEvent EPlayerEnteredRoom = new();
    }
}
