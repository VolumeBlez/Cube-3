using UnityEngine;
using VB;
using Zenject;

public class LevelInstance : MonoBehaviour
{
    [Inject]
    public void InitObserver(GameObserver observer, EnemyStateMachine enemy, PlayerController playerController, InputHandler inputHandler)
    {
        observer.AddListener(playerController);
        observer.AddListener(enemy);

        inputHandler.Input.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        observer.StartGame();
    }
}
