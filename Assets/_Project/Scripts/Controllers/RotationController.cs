using UnityEngine;
using UnityEngine.AI;

public class RotationController : Controller
{
    private Transform _transform;
    private float _rotationSpeed;
    private NavMeshAgent _agent;

    private Vector3 _targetPosition;

    public RotationController(Transform transform, float rotationSpeed, NavMeshAgent agent)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
        _agent = agent;
        _agent.updateRotation = false;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (_targetPosition != Vector3.zero && Vector3.Distance(_transform.position, _targetPosition) > 0.5f)
        {
            Quaternion angle = Quaternion.LookRotation(_targetPosition - _transform.position);
            float stepRotation = _rotationSpeed * deltaTime;
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, angle, stepRotation);
        }
    }

    public void SetRotationDirection(Vector3 point) => _targetPosition = point;
}
