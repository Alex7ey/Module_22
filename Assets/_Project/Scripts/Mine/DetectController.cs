using UnityEngine;

public class DetectController : Controller
{
    private IDetect _detect;
    private float _radius;
    private Transform _transform;

    public DetectController(IDetect detect, float radius, Transform transform)
    {
        _detect = detect;
        _radius = radius;
        _transform = transform;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _radius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable damagable))
            {
                _detect.Detected();
            }
        }
    }
}
