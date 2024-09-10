using Polyperfect.Crafting.Demo;
using UnityEngine;

namespace Core.SaveSystem.Scripts.Commands
{
    public class LoadGameCommand : BaseCommand
    {
        readonly int _levelID;

        public LoadGameCommand(int levelID)
        {
            _levelID = levelID;
        }

        public void Execute()
        {
            // Execute load
            SaveManager.Instance.LoadGame(_levelID);
            Debug.Log($"Game loaded for level {_levelID}");
        }
    }
}
