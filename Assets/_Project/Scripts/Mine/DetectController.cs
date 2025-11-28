using UnityEngine;

public class DetectController : Controller
{
    private IDetect _detect;
    private float _radius;
    private Transform _transform;

    private Collider[] _collider = new Collider[1];

    public DetectController(IDetect detect, float radius, Transform transform)
    {
        _detect = detect;
        _radius = radius;
        _transform = transform;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Physics.OverlapSphereNonAlloc(_transform.position, _radius, _collider);

        if (_collider[0].TryGetComponent(out IDamagable damagable))
        {
            _detect.Detected();
        } 
    }
}
