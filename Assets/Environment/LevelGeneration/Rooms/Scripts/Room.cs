using UnityEngine;

namespace Environment.LevelGeneration.Rooms.Scripts
{
    public class Room : MonoBehaviour
    {
        [SerializeField] Transform roomCenter;
        int _roomID;


        // A simple script to define a room, attach this to each room
        public Transform GetRoomCenter()
        {
            return roomCenter;
        }
        public int getRoomId()
        {
            return _roomID;
        }
    }
}
