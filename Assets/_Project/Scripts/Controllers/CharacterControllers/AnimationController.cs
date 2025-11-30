using UnityEngine;

public class AnimationController : Controller
{
    private readonly Animator _animator;
    private readonly Transform _transform;

    private readonly IMovable _movable;
    private readonly IHealthSystem _healthSystem;

    private readonly int _moveKey = Animator.StringToHash("MovementSpeed");
    private readonly int _healthKey = Animator.StringToHash("Health");
    private readonly int _hitKey = Animator.StringToHash("Hit");
    private readonly int _deadKey = Animator.StringToHash("Dead");

    public AnimationController(IHealthSystem healthSystem, IMovable movable, Animator animator, Transform transform)
    {
        _healthSystem = healthSystem;
        _animator = animator;
        _movable = movable;
        _transform = transform;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        SetMovementParameter();
        SetHealthParameter();

        if (IsTakeDamage())
            TriggerDamageAnimation();

        if (IsAlive() == false)
            TriggerDeathAnimation();
    }

    private void SetMovementParameter() => _animator.SetFloat(_moveKey, (_movable.CurrentPositionTarget - _transform.position).magnitude);

    private void SetHealthParameter() => _animator.SetFloat(_healthKey, _healthSystem.CurrentHealth / _healthSystem.MaxHealth);

    private void TriggerDamageAnimation() => _animator.SetTrigger(_hitKey);

    private void TriggerDeathAnimation() => _animator.SetBool(_deadKey, true);

    private bool IsTakeDamage() => _healthSystem.IsTakeDamage;

    private bool IsAlive() => _healthSystem.IsAlive;
}
