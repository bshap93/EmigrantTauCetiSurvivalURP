using Characters.Health.Scripts.States.OxygenState;
using Core.Events.EventManagers;
using UI.InGameConsole.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace Characters.Health.Scripts.States
{
    public class HealthSystem : MonoBehaviour
    {
        // Event to notify observers when health changes

        readonly InGameConsoleManager _inGameConsoleManager;
        public readonly string CharacterName;
        ICharacterEventManager _characterEventManager;

        [SerializeField] IOxygenState _oxygenState;
        [SerializeField] IOxygenState initialOxygenState;
        public HealthSystem(float maxOxygen)
        {
            MaxOxygen = maxOxygen;
        }


        public float MaxOxygen { get; }
        public float MaxSuitIntegrity { get; }

        public float CurrentSuitIntegrity { get; set; }
        public float CurrentOxygen { get; set; }


        void Start()
        {
            _characterEventManager = gameObject.GetComponent<ICharacterEventManager>();

            // Subscribe to the OnHealthChanged event
            UnityAction<float> healthChange = OnHealthChangedHandler;
            _characterEventManager.AddListenerToHealthChangedEvent(healthChange);

            UnityAction<float> oxygenChange = OnOxygenChangedHandler;
            _characterEventManager.AddListenerToOxygenChangedEvent(oxygenChange);
        }

        public void ChangeOxygenState(IOxygenState oxygenState)
        {
            _oxygenState.Exit();
            _oxygenState = oxygenState;
            _oxygenState.Enter();
        }


        void OnHealthChangedHandler(float health)
        {
            if (CurrentSuitIntegrity <= 0) _characterEventManager.TriggerCharacterDied(CharacterName);
        }

        void OnOxygenChangedHandler(float oxygen)
        {
            if (CurrentOxygen <= 0) _characterEventManager.TriggerCharacterDied(CharacterName);
        }
        public void HealSuitIntegrity(float value)
        {
            CurrentSuitIntegrity += value;
            if (CurrentSuitIntegrity > MaxSuitIntegrity) CurrentSuitIntegrity = MaxSuitIntegrity;
            _characterEventManager.TriggerCharacterChangeHealth(CurrentSuitIntegrity);
        }

        public void HealOxygen(float value)
        {
            CurrentOxygen += value;
            if (CurrentOxygen > MaxOxygen) CurrentOxygen = MaxOxygen;
            _characterEventManager.TriggerCharacterChangeHealth(CurrentOxygen);
        }
    }
}
