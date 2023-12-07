using UnityEngine;

public abstract class BasePlayerView : MonoBehaviour
{
    protected IPlayerPresenter Presenter;
    protected bool IsInitialized = false;

    public virtual void InitView(IPlayerPresenter presenter) 
    {
        Presenter = presenter;
        IsInitialized = true;
    }
}
