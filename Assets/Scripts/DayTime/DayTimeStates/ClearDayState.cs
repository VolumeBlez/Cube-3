public class ClearDayState : IDayTimeState
{
    private readonly DayTimeStateMachine _stateMachine;

    public ClearDayState(DayTimeStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _stateMachine.Settings.SetDay();
        _stateMachine.Settings.ClearSky();
    }

    public void Exit()
    {
    }
}
