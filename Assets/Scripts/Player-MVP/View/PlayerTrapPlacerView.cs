using UnityEngine;
using Zenject;

public class PlayerTrapPlacerView : BasePlayerView
{
    [SerializeField] private Trap _trapPrefab;
    [SerializeField] private Transform _placePoint;

    [Inject]
    private InputHandler _handler;


    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);

        _handler.Input.Gameplay.Place.performed += ctx => PlaceTrap();
    }

    private void PlaceTrap()
    {
        if(Presenter.Model.Inventory.TryRemove(ItemType.Trap) == true)
        {
            Instantiate(_trapPrefab, _placePoint.position, Quaternion.identity, null);
        }
    }

}
