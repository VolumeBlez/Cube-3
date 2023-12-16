public class PlayerDamageableView : BasePlayerView, IDamageable
{
    private Health _health;

    public void ApplyDamage(int value)
    {
        _health?.Decrease(value);
    }

    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _health = Presenter.Model.Health;
    }
}