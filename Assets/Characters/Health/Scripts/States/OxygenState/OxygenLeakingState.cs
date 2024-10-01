using System;
using Characters.Player.Scripts;
using DG.Tweening;
using UnityEngine;

namespace Characters.Health.Scripts.States.OxygenState
{
    public class OxygenLeakingState : IOxygenState
    {
        readonly HealthSystem _healthSystem;
        readonly PlayerCharacter _playerCharacter;

        public OxygenLeakingState(HealthSystem healthSystem)
        {
            _healthSystem = healthSystem;
            _playerCharacter = PlayerCharacter.Instance;
        }
        public void Update()
        {
            _playerCharacter.playerEventManager.TriggerCharacterChangeOxygen(_healthSystem.currentOxygen);
            Debug.Log("Oxygen is at " + _healthSystem.currentOxygen);
        }
        public void Enter()
        {
            DOTween.To(() => _healthSystem.currentOxygen, x => _healthSystem.currentOxygen = x, 0, 5);
        }
        public void Exit()
        {
            throw new NotImplementedException();
        }

        public HealthSystem.OxygenState GetState()
        {
            return HealthSystem.OxygenState.Leaking;
        }
    }
}
