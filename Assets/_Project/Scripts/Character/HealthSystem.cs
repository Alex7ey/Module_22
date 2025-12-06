using UnityEngine;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    private int _maxHealth;
    private int _currentHealth;

    public bool IsAlive => _currentHealth > 0;
    public bool IsTakeDamage { get; private set; }
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void Inizialize(int maxHealth)
    {
        _currentHealth = maxHealth;
        _maxHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || IsAlive == false)
            return;

        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            return;
        }

        IsTakeDamage = true;
    }

    private void Update()
    {
        IsTakeDamage = false;
    }
}
