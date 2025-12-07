using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Character : MonoBehaviour, IMovable, IRotate, IMortal
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private int _maxHealth;

    private NavMeshAgent _agent;

    private DirectionalMover _directionalMover;
    private DirectionalRotator _directionalRotator;

    public Vector3 CurrentPositionTarget => _directionalMover.CurrentPositionTarget;
    public Vector3 CurrentDirectionToTarget => CurrentPositionTarget - transform.position;
    public Vector3 CurrentPosition => transform.position;
    public bool IsDead { get; private set; }

    public void MoveTo(Vector3 point)
    {
        if (IsDead)
            return;

        _directionalMover.SetMovePoint(point);
        SetLookAtPosition(point);
    }

    public void SetLookAtPosition(Vector3 point)
    {
        _directionalRotator.SetLookAtPosition(point);
    }

    public void Die() => IsDead = true;

    private void Awake()
    {
        _agent = GetComponentInChildren<NavMeshAgent>();

        _directionalMover = new(_agent, _movementSpeed);
        _directionalRotator = new(transform, _rotationSpeed, _agent);
    }

    private void Update()
    {
        _directionalRotator.Update(Time.deltaTime);
    }
}
