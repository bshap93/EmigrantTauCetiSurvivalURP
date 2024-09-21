using Characters.Enemies;
using Combat.TurnManager;
using Combat.TurnManager.TurnStates;
using UnityEngine;

namespace Characters.Player.Scripts.States
{
    public class EnemyTurnState : TurnState
    {
        readonly Enemy[] _enemies;
        int _currentEnemyIndex;

        public EnemyTurnState(Enemy[] enemies)
        {
            _enemies = enemies;
        }

        public override void EnterState(TurnManager turnManager)
        {
            Debug.Log("Enemies' Turn!");
            _currentEnemyIndex = 0;
            ActEnemy(turnManager, _enemies[_currentEnemyIndex]);
        }

        public override void UpdateState(TurnManager turnManager)
        {
            if (turnManager.HasCompletedAction(_enemies[_currentEnemyIndex]))
            {
                _currentEnemyIndex++;
                if (_currentEnemyIndex >= turnManager.enemies.Length)
                    turnManager.ChangeState(new PlayerTurnState()); // Go back to player's turn
                else
                    ActEnemy(turnManager, _enemies[_currentEnemyIndex]);
            }
        }

        void ActEnemy(TurnManager turnManager, Enemy enemy)
        {
            if (_currentEnemyIndex < turnManager.enemies.Length)
                turnManager.StartTurn(enemy);
        }

        public override void ExitState(TurnManager turnManager)
        {
            Debug.Log("Exiting Enemy Turn State.");
        }
    }
}
