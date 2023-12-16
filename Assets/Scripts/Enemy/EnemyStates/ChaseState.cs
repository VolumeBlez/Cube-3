using UnityEngine;

public class ChaseState : IEnemyState
{
    private readonly EnemyStateMachine _stateMachine;
    private Transform _self;
    public ChaseState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _self = _stateMachine.transform;
    }

    public void Exit()
    {
    }

    public void Update()
    {
        CheckPlayerInSight();
    }

    private void CheckPlayerInSight()
    {
        bool playerInAttackRange = Physics.CheckSphere(_self.position, _stateMachine.Config.AttackRange, _stateMachine.Config.WhatIsPlayer);
        
        if(playerInAttackRange)
            _stateMachine.EnterIn<AttackState>();
        else
        {
            bool playerInSightRange = Physics.CheckSphere(_self.position, _stateMachine.Config.SightRange, _stateMachine.Config.WhatIsPlayer);

            if(playerInSightRange){
                Chase();
            }
            else{
                _stateMachine.EnterIn<PatrolState>();
            }
        }
    }

    private void Chase()
    {
        _stateMachine.Agent.SetDestination(_stateMachine.Player.transform.position);
    }
}
