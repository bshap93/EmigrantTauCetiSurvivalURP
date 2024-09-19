using Characters.Enemies.States;
using UnityEngine;

namespace Characters.Enemies.Scripts
{
    public class EnemyStateController : MonoBehaviour
    {
        EnemyState _currentState;
        Enemy _enemy;

        public void Update()
        {
            if (_currentState != null) _currentState.Update(_enemy);
        }

        public void Initialize(Enemy enemy, EnemyState initialState)
        {
            _enemy = enemy;
            _currentState = initialState;
            _currentState.Enter(_enemy); // Set the initial state
        }

        public void ChangeState(EnemyState newState)
        {
            if (_currentState != null)
                _currentState.Exit(_enemy);

            _currentState = newState;
            _currentState.Enter(_enemy);

            Debug.Log("Changed state to " + _currentState.GetType().Name);
        }
    }
}
