public class HealthController : Controller, IHealthSystem
{
    private int _currentHealth;
    private int _maxHealth;

    public HealthController(int maxHealth)
    {
        _currentHealth = maxHealth;
        _maxHealth = maxHealth;
    }

    public bool IsAlive => _currentHealth > 0;
    public bool IsTakeDamage { get; private set; }
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || IsAlive == false)
            return;

        _currentHealth -= damage;

        if (IsAlive == false)
        {
            _currentHealth = 0;
            return;
        }

        IsTakeDamage = true;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        IsTakeDamage = false;
    }
}
