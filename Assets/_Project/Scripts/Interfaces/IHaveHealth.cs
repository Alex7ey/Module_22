public interface IHaveHealth
{
    int CurrentHealth { get; }
    int MaxHealth { get; }
    bool IsInjured { get; }
    bool IsAlive { get; }

    void TakeDamage(int value);
}
