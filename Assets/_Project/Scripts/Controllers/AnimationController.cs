using UnityEngine;

public class AnimationController : Controller
{
    private Animator _animator;

    private IMovable _movable;
    private IHaveHealth _health;
    private Transform _transform;


    public AnimationController(IHaveHealth health, IMovable movable, Animator animator, Transform transform)
    {
        _health = health;
        _animator = animator;
        _movable = movable;
        _transform = transform;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _animator.SetFloat("MovementSpeed", (_movable.CurrentDirectionToTarget - _transform.position).magnitude);
        _animator.SetFloat("Health", _health.CurrentHealth / _health.MaxHealth);

        if (_health.IsInjured)
        {
            _animator.SetTrigger("Hit");
        }

        if(_health.IsAlive == false)
            _animator.SetBool("Dead", true);
    }
}
