using System.Collections;
using UnityEngine;
using Zenject;

public class LevelInstance : MonoBehaviour
{
    [Inject]
    private DayTimeStateMachine _machine;

    void Start()
    {
        SetNight();
    }

    private void SetNight()
    {
        _machine.EnterIn<ClearNightState>();
    }

}
