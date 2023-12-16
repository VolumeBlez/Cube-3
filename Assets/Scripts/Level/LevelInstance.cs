using UnityEngine;
using Zenject;

public class LevelInstance : MonoBehaviour
{
    [Inject]
    public void InitObserver(GameObserver observer, PlayerSetup player, InputHandler input, EnemyStateMachine enemy)
    {

        observer.AddListener(player);
        observer.AddListener(input);
        observer.AddListener(enemy);

        observer.StartGame();
    }
}
