using Characters.Player.Scripts;
using Core.Levels;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.SaveSystem.Scripts
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] LevelManager levelManager;
        public static SaveManager Instance { get; private set; }

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
            if (levelManager == null)
                levelManager = LevelManager.Instance;
        }

        [Button("Save Game")]
        public void SaveGame(int levelID, LevelState levelState)
        {
            // Save player data
            ES3.Save("playerPosition", PlayerCharacter.Instance.transform.position);
            ES3.Save("playerHealth", PlayerCharacter.Instance.GetCurrentHealth());

            // Save the current level seed and dynamic state
            ES3.Save("dungeonSeed_" + levelID, levelState.dungeonSeed); // Save seed as int
            ES3.Save("levelState_" + levelID, levelState);              // Save level-specific data

            levelManager.currentLevelState = levelState;

            Debug.Log("Game saved for level " + levelID);
        }

        [Button("Load Game")]
        public void LoadGame(int levelID)
        {
            if (ES3.FileExists("SaveFile.es3"))
            {
                // Load player data
                PlayerCharacter.Instance.transform.position = ES3.Load<Vector3>("playerPosition");
                PlayerCharacter.Instance.HealthSystem.CurrentHealth = ES3.Load<float>("playerHealth");

                // Load level-specific data, including the dungeon seed
                levelManager.currentLevelState = ES3.Load<LevelState>("levelState_" + levelID);

                // Reinitialize the random state using the loaded seed
                Random.InitState(levelManager.currentLevelState.dungeonSeed);

                Debug.Log("Game loaded for level " + levelID);
            }
            else
            {
                Debug.LogWarning("No save file found. Starting a new game.");
                levelManager.GenerateNewLevel();
            }
        }

        public bool HasLevelData(int levelID)
        {
            var data = ES3.KeyExists("dungeonSeed_" + levelID) && ES3.KeyExists("levelState_" + levelID);
            Debug.Log("Level data exists for level " + levelID + ": " + data);
            return data;
        }

        public void StartNewGame()
        {
            // Initialize new game state
            PlayerCharacter.Instance.ResetPlayer();
            Random.InitState(System.Environment.TickCount);
            Debug.Log("New game started!");
        }

        public int GetLevelSeed(int currentLevelID)
        {
            return ES3.Load<int>("dungeonSeed_" + currentLevelID); // Load the seed as an int
        }
    }
}
