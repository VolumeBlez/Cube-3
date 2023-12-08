using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [Header("Player Datas")]
    [SerializeField] private PlayerAudioClipsData _audioClips;
    [SerializeField] private PlayerData _data;
    
    [Header("Player Views")]
    [SerializeField] private PlayerIndicator _indicator;
    [SerializeField] private BasePlayerView[] _views;

    public void Start()
    {
        PlayerModel model = new PlayerModel(_data, _audioClips);
        IPlayerPresenter presenter = new PlayerPresenter(model);

        _indicator.Init(presenter);

        presenter
            .RegisterService(new PlayerAudioService(model, presenter, model.Data.AudioSource))
            .RegisterService(new PlayerMotorService(model, presenter))
            .RegisterService(new PlayerRayService(model, presenter))
            .RegisterService(new PlayerDieService(model, presenter));

        foreach (BasePlayerView view in _views)
        {
            view.InitView(presenter);
        }
    }
}
