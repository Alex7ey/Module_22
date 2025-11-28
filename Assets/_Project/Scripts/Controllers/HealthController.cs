public class HealthController : Controller, IDamagable, IHaveHealth
{
    private int _currentHealth;
    private int _maxHealth;

    public HealthController(int currentHealth)
    {
        _currentHealth = currentHealth;
        _maxHealth = currentHealth;
    }

    public bool IsAlive => _currentHealth > 0;
    public bool IsInjured { get; private set; }
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void TakeDamage(int value)
    {
        _currentHealth -= value;

        if (_currentHealth > 0)
        {
            IsInjured = true;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }
            return;
        }
    }

    protected override void UpdateLogic(float deltaTime)
    {
        IsInjured = false;
    }

}
