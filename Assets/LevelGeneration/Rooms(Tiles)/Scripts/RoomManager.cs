using LevelGeneration.GenerationAssets.Tiles.BasicRooms.Scripts;
using Sirenix.Utilities;
using UnityEngine;

namespace LevelGeneration.GenerationAssets.Tiles.Scripts
{
    public class RoomManager : MonoBehaviour
    {
        public Room[] rooms;

        public static RoomManager Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Keep the manager across scenes
            }
            else
            {
                Destroy(gameObject); // Prevent duplicates
            }

            // Attempt to find rooms in Awake, but will also try in Update if not yet initialized
            rooms = FindObjectsOfType<Room>();
        }

        void Update()
        {
            // Check if rooms are still null or empty
            if (rooms.IsNullOrEmpty()) rooms = FindObjectsOfType<Room>();

            // If rooms are found, stop calling Update
            if (!rooms.IsNullOrEmpty())
            {
                foreach (var room in rooms) UnityEngine.Debug.Log("Room " + room.getRoomId());

                // Disable Update by setting the enabled property to false
                enabled = false; // Disables the Update method from running again
            }
        }
    }
}
