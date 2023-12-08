using System;
using System.Collections.Generic;

public class PlayerPresenter : IPlayerPresenter
{
    private readonly Dictionary<Type, BasePlayerService> _registeredServiceMap = new();

    public PlayerPresenter(IPlayerModel model)
    {
        Model = model;
    }

    public IPlayerModel Model { get; }

    public IPlayerPresenter RegisterService(BasePlayerService service)
    {
        _registeredServiceMap.Add(service.GetType(), service);
        return this;
    }

    public T GetService<T>() where T : BasePlayerService
    {
        return (T)_registeredServiceMap[typeof(T)];
    }

    public void SetModel(IPlayerModel model)
    {
        throw new NotImplementedException();
    }

}
