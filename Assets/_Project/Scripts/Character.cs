using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Character : MonoBehaviour, IMovable, IRotate, IDamagable, IHealable
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _destinationMarker;
    [SerializeField] private Image _healthBar;

    private Animator _animator;
    private NavMeshAgent _agent;

    private InputMouseController _inputMouseController;
    private MovementNavMeshAgentController _movementController;
    private RotationController _rotationController;
    private AnimationController _animationController;
    private HealthController _healthController;
    private DestinationMarkerController _destinationMarkerController;
    private ProgressBarController _healthBarController;
    private PointClickMovementController _pointClickMovementController;

    private CompositeController _controllers;

    public Vector3 CurrentPositionTarget => _movementController.CurrentPositionTarget;
    public Vector3 CurrentDirectionToTarget => _movementController.CurrentPositionTarget - transform.position;

    public void MoveTo(Vector3 point)
    {
        if (_movementController.IsValidPath(point) && _healthController.IsAlive)
        {
            _movementController.SetMovePoint(point);
            _destinationMarkerController.SetMarkerPosition(point);
            SetLookAtPosition(point);
        }
    }

    public void SetLookAtPosition(Vector3 point)
    {
        _rotationController.SetLookAtPosition(point);
    }

    public void TakeDamage(int damage)
    {
        _healthController.TakeDamage(damage);
        _healthBarController.SetValueProgress(_healthController.CurrentHealth);
    }

    public void Heal(int amount)
    {
        _healthController.Healling(amount);
        _healthBarController.SetValueProgress(_healthController.CurrentHealth);
    }

    private void Awake()
    {
        InitializeComponents();

        CreateControllers();
        EnableControllers();
    }

    private void Update() => UpdateControllers();

    private void CreateControllers()
    {
        _inputMouseController = new();
        _pointClickMovementController = new(this, _inputMouseController);

        _movementController = new(_agent, _movementSpeed, transform.position);
        _rotationController = new(transform, _rotationSpeed, _agent);

        _healthController = new(_maxHealth);
        _healthBarController = new(_healthBar, _maxHealth);
        _destinationMarkerController = new(_destinationMarker, transform);
        _animationController = new(_healthController, this, _animator, transform);

        _controllers = 
           new(
           _pointClickMovementController,
           _rotationController,
           _inputMouseController,
           _animationController,
           _healthController,
           _destinationMarkerController
           );
    }

    private void InitializeComponents()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponentInChildren<NavMeshAgent>();
    }

    private void EnableControllers() => _controllers.Enable();

    private void UpdateControllers() => _controllers.Update(Time.deltaTime);

}
