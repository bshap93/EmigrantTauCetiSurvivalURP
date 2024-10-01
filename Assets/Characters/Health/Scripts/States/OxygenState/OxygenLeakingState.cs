using System;

namespace Characters.Health.Scripts.States.OxygenState
{
    public class OxygenLeakingState : IOxygenState
    {
        HealthSystem _healthSystem;

        public OxygenLeakingState(HealthSystem healthSystem)
        {
            _healthSystem = healthSystem;
        }
        public void Update()
        {
            
        }
        public void Enter()
        {
            
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
