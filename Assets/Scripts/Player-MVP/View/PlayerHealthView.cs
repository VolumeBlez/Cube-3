public class PlayerHealthView : BasePlayerView, IDamageable
{
    private Health _health;
    private PlayerDieService _dieService;

    public override void InitView(IPlayerPresenter presenter)
    {
        base.InitView(presenter);
        _dieService = Presenter.GetService<PlayerDieService>();

        _health = new Health(presenter.Model.Data.StartMaxHealth);
        _health.HealthChange += CheckDie;
    }

    public void ApplyDamage(int value)
    {
        _health.Decrease(value);
    }

    private void CheckDie(int currentHealth)
    {
        if(currentHealth <= 0)
            _dieService?.PlayerDie();
    }
}
