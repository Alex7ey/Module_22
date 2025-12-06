using UnityEngine;

public class ViewCharacter : MonoBehaviour
{
    private Animator _animator;

    private IMovable _movable;
    private IHealthSystem _healthSystem;

    private int _moveKey = Animator.StringToHash("MovementSpeed");
    private int _healthKey = Animator.StringToHash("Health");
    private int _hitKey = Animator.StringToHash("Hit");
    private int _deadKey = Animator.StringToHash("Dead");

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _movable = GetComponent<IMovable>();
        _healthSystem = GetComponent<IHealthSystem>();
    }

    private void Update()
    {
        SetMovementParameter();
        SetHealthParameter();

        if (IsTakeDamage())
            TriggerDamageAnimation();

        if (IsAlive() == false)
            TriggerDeathAnimation();
    }

    private void SetMovementParameter() => _animator.SetFloat(_moveKey, (_movable.CurrentDirectionToTarget).magnitude);

    private void SetHealthParameter() => _animator.SetFloat(_healthKey, _healthSystem.CurrentHealth / _healthSystem.MaxHealth);

    private void TriggerDamageAnimation() => _animator.SetTrigger(_hitKey);

    private void TriggerDeathAnimation() => _animator.SetBool(_deadKey, true);

    private bool IsTakeDamage() => _healthSystem.IsTakeDamage;

    private bool IsAlive() => _healthSystem.IsAlive;
}
