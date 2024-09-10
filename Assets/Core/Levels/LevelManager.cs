using Core.SaveSystem.Scripts;
using DunGen;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Levels
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        // UnityEvent for when the level is generated (does not require the DungeonGenerator parameter)
        public UnityEvent OnLevelGenerated;

        public DungeonGenerator dungeonGenerator; // Reference to DunGen's DungeonGenerator
        public int currentLevelID;
        public LevelState currentLevelState;

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

        [Button("Generate or Load Level")]
        public void GenerateOrLoadLevel()
        {
            if (SaveManager.Instance.HasLevelData(currentLevelID))
                LoadLevel();
            else
                GenerateNewLevel();
        }

        [Button("Generate New Level")]
        public void GenerateNewLevel()
        {
            // Generate a new procedural level using DunGen
            currentLevelState = new LevelState();
            // Set the seed for the dungeon generator
            currentLevelState.dungeonSeed = Random.Range(0, int.MaxValue); // Create new seed
            dungeonGenerator.Seed = currentLevelState.dungeonSeed;         // Set the seed

            SaveManager.Instance.SaveGame(currentLevelID, currentLevelState);

            // Subscribe to DunGen's OnGenerationComplete event
            dungeonGenerator.OnGenerationComplete += HandleDungeonGenerated;

            // Start generating the dungeon
            dungeonGenerator.Generate();
        }

        [Button("Load Level")]
        public void LoadLevel()
        {
            SaveManager.Instance.LoadGame(currentLevelID);

            // Retrieve the saved seed from the LevelState and set it to DunGen
            dungeonGenerator.Seed = currentLevelState.dungeonSeed;

            // Load level-specific data (DunGen can regenerate based on saved seed)
            dungeonGenerator.OnGenerationComplete += HandleDungeonGenerated;

            // Start generating the dungeon using DunGen
            dungeonGenerator.Generate();
        }

        // Called when DunGen completes the dungeon generation
        void HandleDungeonGenerated(DungeonGenerator generator)
        {
            // Unsubscribe to avoid multiple triggers
            dungeonGenerator.OnGenerationComplete -= HandleDungeonGenerated;

            // Invoke the custom UnityEvent for other listeners
            OnLevelGenerated?.Invoke();

            Debug.Log("Dungeon generated, UnityEvent triggered.");
        }
    }
}
