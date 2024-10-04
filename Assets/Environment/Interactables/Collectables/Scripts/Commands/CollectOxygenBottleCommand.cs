using Characters.Health.Scripts.States;
using Characters.Player.Scripts;
using Core.Events.EventManagers;
using Core.Utilities.Commands;
using UnityEngine;

namespace Environment.Interactables.Collectables.Scripts.Commands
{
    public class CollectOxygenBottleCommand : ISimpleCommand
    {
        readonly GameObject _collectableGameObject;
        readonly ICharacterEventManager _characterEventManager;
        public CollectOxygenBottleCommand(GameObject collectableGameObject)
        {
            _collectableGameObject = collectableGameObject;
            _characterEventManager = PlayerCharacter.Instance.GetComponent<ICharacterEventManager>();
        }
        public void Execute()
        {
            Debug.Log("CollectOxygenBottleCommand Execute");
            _collectableGameObject.SetActive(false);
            _characterEventManager.TriggerCharacterChangeOxygen(HealthSystem.MaxOxygen);
        }
    }
}
