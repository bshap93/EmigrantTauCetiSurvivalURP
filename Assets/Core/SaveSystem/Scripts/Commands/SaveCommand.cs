using Core.Levels;
using Polyperfect.Crafting.Demo;
using UnityEngine;

namespace Core.SaveSystem.Scripts.Commands
{
    public class SaveGameCommand : BaseCommand
    {
        readonly int _levelID;

        public SaveGameCommand(int levelID)
        {
            _levelID = levelID;
        }

        public void Execute()
        {
            // Execute save
            SaveManager.Instance.SaveGame(_levelID, LevelManager.Instance.currentLevelState);
            Debug.Log($"Game saved for level {_levelID}");
        }
    }
}
