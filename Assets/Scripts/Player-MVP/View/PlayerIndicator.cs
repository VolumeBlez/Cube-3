using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
    public IPlayerPresenter Presenter { get; private set; }

    public void Init(IPlayerPresenter presenter)
    {
        Presenter = presenter;
    }
}
