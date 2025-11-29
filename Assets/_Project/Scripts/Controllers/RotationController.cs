using UnityEngine;
using UnityEngine.AI;

public class RotationController : Controller
{
    private readonly Transform _transform;
    private readonly float _rotationSpeed;
    private readonly NavMeshAgent _agent;

    private Vector3 _lookAtPosition;

    public RotationController(Transform transform, float rotationSpeed, NavMeshAgent agent)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
        _agent = agent;

        ConfigureNavMeshAgent();
        SetLookAtPosition(transform.position + transform.forward);
    }

    public void SetLookAtPosition(Vector3 point) => _lookAtPosition = point;

    protected override void UpdateLogic(float deltaTime)
    {
        if (CanRotate())
            ProcessRotate(deltaTime);
    }

    private void ProcessRotate(float deltaTime)
    {
        Vector3 direction = _lookAtPosition - _transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion angle = Quaternion.LookRotation(direction);
            float stepRotation = _rotationSpeed * deltaTime;
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, angle, stepRotation);
        }
    }

    private bool CanRotate() => Vector3.Distance(_transform.position, _lookAtPosition) > _agent.stoppingDistance;

    private void ConfigureNavMeshAgent() => _agent.updateRotation = false;
}
