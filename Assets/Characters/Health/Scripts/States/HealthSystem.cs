using System;
using Characters.Health.Scripts.States.OxygenState;
using Core.Events.EventManagers;
using UI.InGameConsole.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Characters.Health.Scripts.States
{
    public class HealthSystem : MonoBehaviour
    {
        [Serializable]
        public enum OxygenState
        {
            Stable,
            Leaking
        }

        public string characterName;


        public float maxOxygen;
        [SerializeField] public float maxSuitIntegrity;

        public float currentSuitIntegrity;
        public float currentOxygen;
        [FormerlySerializedAs("oxygenState")] public OxygenState oxygenStateInitial;
        ICharacterEventManager _characterEventManager;
        // Event to notify observers when health changes

        InGameConsoleManager _inGameConsoleManager;

        IOxygenState _oxygenState;


        void Start()
        {
            _characterEventManager = gameObject.GetComponent<ICharacterEventManager>();

            // Subscribe to the OnHealthChanged event
            UnityAction<float> healthChange = OnHealthChangedHandler;
            _characterEventManager.AddListenerToHealthChangedEvent(healthChange);

            UnityAction<float> oxygenChange = OnOxygenChangedHandler;
            _characterEventManager.AddListenerToOxygenChangedEvent(oxygenChange);

            switch (oxygenStateInitial)
            {
                case OxygenState.Stable:
                    var oxygenStableState = new OxygenStableState(this);
                    ChangeOxygenState(oxygenStableState);
                    break;
                case OxygenState.Leaking:
                    var oxygenLeakingState = new OxygenLeakingState(this);
                    ChangeOxygenState(oxygenLeakingState);
                    break;
            }
        }

        public IOxygenState GetOxygenState()
        {
            return _oxygenState;
        }

        public void ChangeOxygenState(IOxygenState oxygenState)
        {
            if (_oxygenState != null) _oxygenState.Exit();
            _oxygenState = oxygenState;
            _oxygenState.Enter();
        }


        void OnHealthChangedHandler(float health)
        {
            if (currentSuitIntegrity <= 0) _characterEventManager.TriggerCharacterDied(characterName);
        }

        void OnOxygenChangedHandler(float oxygen)
        {
            if (currentOxygen <= 0) _characterEventManager.TriggerCharacterDied(characterName);
        }
        public void HealSuitIntegrity(float value)
        {
            currentSuitIntegrity += value;
            if (currentSuitIntegrity > maxSuitIntegrity) currentSuitIntegrity = maxSuitIntegrity;
            _characterEventManager.TriggerCharacterChangeHealth(currentSuitIntegrity);
        }

        public void HealOxygen(float value)
        {
            currentOxygen += value;
            if (currentOxygen > maxOxygen) currentOxygen = maxOxygen;
            _characterEventManager.TriggerCharacterChangeHealth(currentOxygen);
        }
    }
}
