public class PlayerFreeze : BasePlayerView
{
    private ReactiveProperty _freezing;
    private TemperatureChangePreset _preset;
    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _freezing = Presenter.Model.Freezing;
    }

    private void Update()
    {
        if(_preset == null)
            _freezing.Decrease(1);
        else
        {
            if(_preset.Type == TemperatureChangeType.Freeze)
                _freezing.Decrease(_preset.Value);
            else if(_preset.Type == TemperatureChangeType.Heat)
                _freezing.Increase(_preset.Value);
        }
    }

    public void SetTemperaturePreset(TemperatureChangePreset newPreset)
    {
        _preset = newPreset;
    }

    public void SetDefaultTemperaturePreset()
    {
        _preset = null;
    }
}
