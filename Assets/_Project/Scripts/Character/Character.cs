using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Character : MonoBehaviour, IMovable, IRotate, IDamagable
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _maxHealth;

    private NavMeshAgent _agent;

    private DirectionalMover _movementController;
    private DirectionalRotator _rotationController;
    private HealthSystem _healthSystem;

    public Vector3 CurrentPositionTarget => _movementController.CurrentPositionTarget;
    public Vector3 CurrentDirectionToTarget => CurrentPositionTarget - transform.position;
    public Vector3 CurrentPosition => transform.position;

    public void MoveTo(Vector3 point)
    {
        if (_healthSystem.IsAlive == false)
            return;

        _movementController.SetMovePoint(point);
        SetLookAtPosition(point);
    }

    public void SetLookAtPosition(Vector3 point)
    {
        _rotationController.SetLookAtPosition(point);
    }

    public void TakeDamage(int damage)
    {
        _healthSystem.TakeDamage(damage);
    }

    private void Awake()
    {
        _agent = GetComponentInChildren<NavMeshAgent>();
        _healthSystem = GetComponent<HealthSystem>();
        _healthSystem.Inizialize(_maxHealth);

        _movementController = new(_agent, _movementSpeed);
        _rotationController = new(transform, _rotationSpeed, _agent);
    }

    private void Update()
    {
        _rotationController.Update(Time.deltaTime);
    }

}
