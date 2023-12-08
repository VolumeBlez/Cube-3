using System.Collections;
using UnityEngine;
using Zenject;

public class LevelInstance : MonoBehaviour
{
    [Inject]
    private DayTimeStateMachine _machine;

    void Start()
    {
        StartCoroutine(ChangeDayStates());
    }

    private void SetNight()
    {
        _machine.EnterIn<StormyNightState>();
    }

    IEnumerator ChangeDayStates()
    {
        _machine.EnterIn<ClearDayState>();
        yield return new WaitForSeconds(4);
        _machine.EnterIn<StormDayState>();
        yield return new WaitForSeconds(4);
        _machine.EnterIn<StormyNightState>();
        yield return new WaitForSeconds(4);
        _machine.EnterIn<ClearNightState>();
    }

}
