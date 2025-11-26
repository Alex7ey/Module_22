using UnityEngine;

public class RotatorController : Controller
{
    private Transform _transform;
    private Transform _targetTransform;
    private float _rotationSpeed;

    public RotatorController(Transform transform, Transform targetTransform, float rotationSpeed)
    {
        _transform = transform;
        _targetTransform = targetTransform;
        _rotationSpeed = rotationSpeed;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Quaternion angle = Quaternion.LookRotation(_targetTransform.position - _transform.position);
        float stepRotation = _rotationSpeed * deltaTime;
        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, angle, stepRotation);
    }
}
