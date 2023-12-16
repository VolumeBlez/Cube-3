using System;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeStateMachine
{
    private Dictionary<Type, IDayTimeState> _states;
    private List<Type> _keyList = new();
    private IDayTimeState _currentState;

    public SceneRenderSettings Settings { get; private set; }

    public DayTimeStateMachine(SceneRenderSettings settings)
    {
        Settings = settings;
        _states = new Dictionary<Type, IDayTimeState>()
        {
            [typeof(ClearDayState)] = new ClearDayState(this),
            [typeof(ClearNightState)] = new ClearNightState(this),
            [typeof(StormDayState)] = new StormDayState(this),
            [typeof(StormyNightState)] = new StormyNightState(this)
        };

       _keyList = new List<Type>(_states.Keys);
    }

    public void EnterIn<TState>() where TState : IDayTimeState
    {
        if(_states.TryGetValue(typeof(TState), out IDayTimeState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }

    public void EnterInRandomState()
    {
        if(_states.TryGetValue(_keyList[UnityEngine.Random.Range(0, _keyList.Count)], out IDayTimeState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
