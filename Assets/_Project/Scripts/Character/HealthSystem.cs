using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamagable
{
    [SerializeField] private int _maxHealth;

    private IMortal _mortal;
    private int _currentHealth;

    public bool IsAlive => _currentHealth > 0;
    public bool IsTakeDamage { get; private set; }
    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || IsAlive == false)
            return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _mortal.Die();
            return;
        }

        IsTakeDamage = true;
    }

    private void Update()
    {
        IsTakeDamage = false;
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _mortal = GetComponent<IMortal>();
    }
}
