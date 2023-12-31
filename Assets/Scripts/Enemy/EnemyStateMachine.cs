using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyStateMachine : MonoBehaviour
{
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public EnemyConfig Config { get; private set; }
    private Dictionary<Type, IEnemyState> _states;
    private IEnemyState _currentState;

    public Transform SelfTransform => transform;

    [Inject]
    public PlayerIndicator Player { get; private set; }

    private void Start()
    {
        _states = new Dictionary<Type, IEnemyState>()
        {
            [typeof(PatrolState)] = new PatrolState(this),
            [typeof(ChaseState)] = new ChaseState(this)
        };

        Debug.Log(Config);
        EnterIn<PatrolState>();
    }

    public void EnterIn<TState>() where TState : IEnemyState
    {
        if(_states.TryGetValue(typeof(TState), out IEnemyState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }

    private void Update()
    {
        //_currentState.Update();
    }
}
