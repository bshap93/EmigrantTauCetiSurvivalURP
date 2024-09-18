using Characters.CharacterState;
using UnityEngine;

namespace Characters.Enemies.Scripts
{
    public class EnemyStateController : MonoBehaviour
    {
        EnemyState _currentState;

        public void InitializeState(EnemyState initialState)
        {
            _currentState = initialState;
            _currentState.Enter(GetComponent<Enemy>());
        }
    }
}
