using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class DirectionalRotator
{
    private readonly Transform _transform;
    private readonly float _rotationSpeed;
    private readonly NavMeshAgent _agent;
    private Vector3 _lookAtPosition;

    private NavMeshPath _path = new();
    private NavMeshQueryFilter _filter = new();

    public DirectionalRotator(Transform transform, float rotationSpeed, NavMeshAgent agent)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
        _agent = agent;

        ConfigureNavMeshAgent();
        SetLookAtPosition(transform.position + transform.forward);
    }

    public void SetLookAtPosition(Vector3 point) => _lookAtPosition = point;

    public void Update(float deltaTime)
    {
        if (CanRotate())
            ProcessRotate(deltaTime);
    }

    private void ProcessRotate(float deltaTime)
    {
        Vector3 direction = GetTargetRotatePoint() - _transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion angle = Quaternion.LookRotation(direction);
            float stepRotation = _rotationSpeed * deltaTime;
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, angle, stepRotation);
        }
    }

    private Vector3 GetTargetRotatePoint()
    {
        NavMesh.CalculatePath(_transform.position, _lookAtPosition, _filter.areaMask, _path);

        if (_path.corners.Length > 0)
        {
            return _path.corners[1];
        }

        return _lookAtPosition;
    }

    private bool CanRotate() => Vector3.Distance(_transform.position, _lookAtPosition) > _agent.stoppingDistance;

    private void ConfigureNavMeshAgent()
    {
        _agent.updateRotation = false;
        _filter.agentTypeID = 0;
        _filter.areaMask = NavMesh.AllAreas;
    }
}
