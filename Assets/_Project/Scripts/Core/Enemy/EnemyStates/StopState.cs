public class StopState : IEnemyState
{
    private EnemyStateMachine _stateMachine;

    public StopState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public void Enter()
    {
        _stateMachine.Agent.enabled = false;
    }

    public void Exit()
    {
        _stateMachine.Agent.enabled = true;
    }

    public void Update()
    {
    }
}
