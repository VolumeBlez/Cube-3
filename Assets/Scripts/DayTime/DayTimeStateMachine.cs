using System;
using System.Collections.Generic;

public class DayTimeStateMachine
{
    private Dictionary<Type, IDayTimeState> _states;
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
}
