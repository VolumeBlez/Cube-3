using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VB;
using Zenject;

public class EnemyStateMachine : MonoBehaviour, IStartGameListener, IPauseGameListener, IResumeGameListener
{
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public EnemyConfig Config { get; private set; }
    private Dictionary<Type, IEnemyState> _states;
    private IEnemyState _currentState;

    [Inject]
    public PlayerIndicator Player { get; private set; }

    private void Init()
    {
        _states = new Dictionary<Type, IEnemyState>
        {
            [typeof(PatrolState)] = new PatrolState(this),
            [typeof(ChaseState)] = new ChaseState(this),
            [typeof(StopState)] = new StopState(this),
            [typeof(AttackState)] = new AttackState(this)
        };
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
        _currentState?.Update();
    }

    public void OnStartGame()
    {
        Init();
        EnterIn<PatrolState>();
    }

    public void OnPauseGame()
    {
        EnterIn<StopState>();
    }

    public void OnResumeGame()
    {
        EnterIn<PatrolState>();
    }
}
