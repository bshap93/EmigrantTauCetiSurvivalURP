using System.Collections.Generic;
using DunGen;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Core.Levels
{
    public class LevelManager : MonoBehaviour
    {
        // UnityEvent for when the level is generated (does not require the DungeonGenerator parameter)
        public UnityEvent onLevelGenerated;

        public RuntimeDungeon runtimeDungeon;
        public int currentLevelID;

        [SerializeField] int dungeonSeed;

        DungeonGenerator _dungeonGenerator; // Reference to DunGen's DungeonGenerator

        public List<DungeonLevel> DungeonLevels;
        public static LevelManager Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            DungeonLevels = new List<DungeonLevel>();
            if (runtimeDungeon != null) _dungeonGenerator = runtimeDungeon.Generator;
        }

        public void SetSeed(int seed)
        {
            dungeonSeed = seed;
        }

        public int GetSeed()
        {
            return dungeonSeed;
        }


        [Button("Generate New Level")]
        public void GenerateLevel(int? seed)
        {
            // Generate a new procedural level using DunGen
            // Set the seed for the dungeon generator
            if (seed != null)
                dungeonSeed = seed.Value;
            else
                dungeonSeed = Random.Range(0, int.MaxValue); // Create new seed

            _dungeonGenerator.Seed = dungeonSeed; // Set the seed
            currentLevelID++; // Increment the level ID

            DungeonLevels.Add(new DungeonLevel(currentLevelID, dungeonSeed));

            // Subscribe to DunGen's OnGenerationComplete event
            _dungeonGenerator.OnGenerationComplete += HandleDungeonGenerated;


            // Start generating the dungeon
            _dungeonGenerator.Generate();

            onLevelGenerated?.Invoke();
        }


        [Button("Remove Level with Seed")]
        public void RemoveLevelWithSeed(int seed)
        {
            DungeonLevels.RemoveAll(x => x.Seed == seed);
        }

        [Button("List Current Dungeon Levels")]
        public void ListCurrentDungeonLevels()
        {
            foreach (var level in DungeonLevels) Debug.Log($"Level ID: {level.LevelID}, Seed: {level.Seed}");
        }


        // Called when DunGen completes the dungeon generation
        void HandleDungeonGenerated(DungeonGenerator generator)
        {
            // Unsubscribe to avoid multiple triggers
            _dungeonGenerator.OnGenerationComplete -= HandleDungeonGenerated;

            // Invoke the custom UnityEvent for other listeners
            onLevelGenerated?.Invoke();

        }
    }
}
