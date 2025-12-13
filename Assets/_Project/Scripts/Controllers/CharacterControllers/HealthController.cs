public class HealthController : Controller, IHealthSystem
{
    private readonly int _maxHealth;

    private int _currentHealth;

    public HealthController(int maxHealth)
    {
        _currentHealth = maxHealth;
        _maxHealth = maxHealth;
    }

    public bool IsAlive => _currentHealth > 0;
    public bool IsTakeDamage { get; private set; }
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public bool IsHealing { get; private set; }

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

    public void Healling(int health)
    {
        if (_currentHealth < _maxHealth && IsAlive == false)
            return;

        _currentHealth += health;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
            return;
        }

        IsHealing = true;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        IsTakeDamage = false;
        IsHealing = false;
    }
}
