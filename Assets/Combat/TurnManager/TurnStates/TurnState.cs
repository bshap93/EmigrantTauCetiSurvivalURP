namespace Combat.TurnManager.TurnStates
{
    public abstract class TurnState
    {
        public abstract void EnterState(TurnManager turnManager);
        public abstract void UpdateState(TurnManager turnManager);
        public abstract void ExitState(TurnManager turnManager);
    }
}
