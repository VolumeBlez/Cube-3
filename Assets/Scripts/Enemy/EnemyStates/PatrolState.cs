using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{
    private readonly EnemyStateMachine _stateMachine;
    private Transform _target;
    private Transform _self;
    private bool _walkPointSet;
    private Vector3 _walkPoint;

    public PatrolState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _target = _stateMachine.Player.transform;
        _self = _stateMachine.transform;
        _walkPointSet = false;
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
        bool playerInSightRange = Physics.CheckSphere(_self.position, _stateMachine.Config.SightRange, _stateMachine.Config.WhatIsPlayer);
        if(playerInSightRange){
            _stateMachine.EnterIn<ChaseState>();
        }
        else{
            Patrol();
        }
    }

    private void Patrol()
    {
        if(!_walkPointSet) SearchWalkPoint();

        if(_walkPointSet){
            _stateMachine.Agent.SetDestination(_walkPoint);
        }
        Vector3 distanceToWalkPoint = _self.position - _walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
            _walkPointSet = false;
    }

    private void SearchWalkPoint(){

        float randomZ = Random.Range(-_stateMachine.Config.WalkPointRange, _stateMachine.Config.WalkPointRange);
        float randomX = Random.Range(-_stateMachine.Config.WalkPointRange, _stateMachine.Config.WalkPointRange);

        _walkPoint = new Vector3(_self.position.x + randomX, _self.position.y, _self.position.z + randomZ);

        _walkPointSet = true;
    }
}
