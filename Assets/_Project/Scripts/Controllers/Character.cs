using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour, IMovable, IRotate, IDamagable
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _maxHealth;

    [SerializeField] private Transform _targetPosition;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    private InputController _inputController;
    private MovementController _movementController;
    private RotationController _rotationController;
    private AnimationController _animationController;
    private HealthController _healthController;

    private CompositeController _controllers;

    public Vector3 CurrentDirectionToTarget => _movementController.CurrentDirectionToTaget;

    public void MoveTo(Vector3 point)
    {
        if (_inputController.IsLeftMouseButtonDown)
        {
            _movementController.SetMoveDirection(point);
        }
    }

    public void RotationTo(Vector3 point)
    {
        _rotationController.SetRotationDirection(point);
    }

    public void TakeDamage(int damage)
    {
        _healthController.TakeDamage(damage);
    }

    private void Awake()
    {
        CreateControllers();
        EnableControllers();
    }

    private void Update()
    {
        UpdateControllers();
    }

    private void CreateControllers()
    {
        _healthController = new(_maxHealth);
        _movementController = new MovementController(_agent, _movementSpeed);
        _rotationController = new RotationController(transform, _rotationSpeed, _agent);
        _animationController = new AnimationController(_healthController, this, _animator, transform);
        _inputController = new();

        _controllers = new(new MoveRayCastController(this), new RotationInputController(this, this), _rotationController, _inputController, _movementController, _animationController, _healthController);
    }

    private void EnableControllers() => _controllers.Enable();

    private void UpdateControllers() => _controllers.Update(Time.deltaTime);

}
