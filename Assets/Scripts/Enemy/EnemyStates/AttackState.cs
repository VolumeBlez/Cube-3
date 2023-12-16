using UnityEngine;

public class AttackState : IEnemyState
{
    private readonly EnemyStateMachine _stateMachine;
    private readonly Timer _timer;
    private Collider[] _colliders = new Collider[8];

    public AttackState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;

        _timer = new();
        _timer.TimerStop += () => _stateMachine.EnterIn<ChaseState>();
    }

    public void Enter()
    {
        _timer.Start(_stateMachine.Config.AttackCoolDown);
        _stateMachine.Agent.enabled = false;

        int results = Physics.OverlapSphereNonAlloc(_stateMachine.transform.position, _stateMachine.Config.AttackRange, _colliders);

        if(results == 0)
            return;

        for (int i = 0; i < results; i++)
        {
            if(_colliders[i].TryGetComponent(out IDamageable damageable))
            {
                Debug.Log(_colliders[i]);
                damageable.ApplyDamage(_stateMachine.Config.Damage);
            }
        }

    }

    public void Exit()
    {
        _stateMachine.Agent.enabled = true;
    }

    public void Update()
    {
        _timer.Update(Time.deltaTime);
    }
}
