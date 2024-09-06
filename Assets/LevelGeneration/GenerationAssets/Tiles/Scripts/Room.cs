using UnityEngine;

namespace LevelGeneration.GenerationAssets.Tiles.Scripts
{
    public class Room : MonoBehaviour
    {
        [SerializeField] Transform roomCenter;


        // A simple script to define a room, attach this to each room
        public Transform GetRoomCenter()
        {
            return roomCenter;
        }
    }
}
