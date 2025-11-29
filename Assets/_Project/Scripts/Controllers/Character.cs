using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Character : MonoBehaviour, IMovable, IRotate, IDamagable
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _maxHealth;

    [SerializeField] private GameObject _flag;
    [SerializeField] private Image _progressBar;

    private Animator _animator;
    private NavMeshAgent _agent;

    private InputMouseController _inputMouseController;
    private MovementNavMeshAgentController _movementController;
    private RotationController _rotationController;
    private AnimationController _animationController;
    private HealthController _healthController;
    private DestinationMarkerController _destinationMarkerController;
    private ProgressBarController _healthBarController;

    private CompositeController _controllers;

    public Vector3 CurrentDirectionToTarget => _movementController.CurrentPositionTarget;

    public void MoveTo(Vector3 point)
    {
        if (_inputMouseController.IsMoveCommand)
        {
            if (_movementController.IsValidPath(point))
            {
                _movementController.SetMovePoint(point);
                _destinationMarkerController.SetMarkerPosition(point);
                SetLookAtDirection(point);
            }
        }
    }

    public void SetLookAtDirection(Vector3 point)
    {
        _rotationController.SetLookAtPosition(point);
    }

    public void TakeDamage(int damage)
    {
        _healthController.TakeDamage(damage);
        _healthBarController.SetValueProgress(_healthController.CurrentHealth);
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponentInChildren<NavMeshAgent>();

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
        _movementController = new MovementNavMeshAgentController(_agent, _movementSpeed, transform.position);
        _rotationController = new RotationController(transform, _rotationSpeed, _agent);
        _animationController = new AnimationController(_healthController, this, _animator, transform);
        _healthBarController = new(_progressBar, _maxHealth);
        _destinationMarkerController = new(_flag, transform);
        _inputMouseController = new();

        _controllers =
            new(new PointClickMovementController(this, _inputMouseController),
            _rotationController,
            _inputMouseController,
            _animationController,
            _healthController,
            _healthBarController,
            _destinationMarkerController
            );
    }

    private void EnableControllers() => _controllers.Enable();

    private void UpdateControllers() => _controllers.Update(Time.deltaTime);

}
