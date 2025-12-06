using UnityEngine;

public class RadiusDetector
{
    private readonly IDetect _detect;
    private readonly float _radius;
    private readonly Transform _transform;

    public RadiusDetector(IDetect detect, float radius, Transform transform)
    {
        _detect = detect;
        _radius = radius;
        _transform = transform;
    }

    public void Update(float deltaTime)
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable _))
            {
                _detect.Detected();
                break;
            }
        }
    }
}
