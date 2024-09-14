using System;
using Core.Events;
using Core.Spawning.Scripts;
using DunGen;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Environment.LevelGeneration.Rooms.Scripts
{
    public class Room : MonoBehaviour
    {
        public SpawnPoint25D[] enemySpawnPoints; // Define where enemies can spawn in this room
        public GameObject[] enemyPrefabs; // Different enemy types that can be spawned
        [SerializeField] int baseEnemyCount; // Number of enemies to spawn in this room
        [SerializeField] bool hasVerticality; // If the room has verticality, enemies can spawn on different floors

        [SerializeField] Transform roomCenter;
        [SerializeField] int difficultyLevel;

        [SerializeField] RoomType roomType;

        [SerializeField] int roomID;
        Tile _roomTile;

        void Start()
        {
            _roomTile = GetComponent<Tile>();
            EventManager.EPlayerEnteredRoom.AddListener(OnPlayerEnterRoom);
        }

        public void InitializeRoom(int id)
        {
            roomID = id;
            Debug.Log($"Room initialized with ID: {roomID}");
        }


        void OnPlayerEnterRoom()
        {
            SpawnEnemies(difficultyLevel);
            Debug.Log($"Player entered Room ID: {roomID}");
        }
        void SpawnEnemies(int difficultyNumAddEnemies)
        {
            var enemyCount = Mathf.Min(
                enemySpawnPoints.Length,
                baseEnemyCount + difficultyNumAddEnemies); // Scale enemy count based on difficulty

            for (var i = 0; i < enemyCount; i++)
            {
                var spawnPoint = enemySpawnPoints[i];
                if (spawnPoint.CanSpawn())
                {
                    var enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                    Instantiate(enemyPrefab, spawnPoint.GetSpawnPosition(), Quaternion.identity);
                    spawnPoint.MarkOccupied();
                }
            }
        }


        // A simple script to define a room, attach this to each room
        public Transform GetRoomCenter()
        {
            return roomCenter;
        }
        public int GetRoomId()
        {
            return roomID;
        }

        [Serializable]
        enum RoomType
        {
            CapRoom,
            Corridor,
            Room3X3,
            Other
        }
    }
}
