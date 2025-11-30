using UnityEngine;

public class Mine : MonoBehaviour, IDetect
{
    [SerializeField] private float _detectionRadius;
    [SerializeField] private float _timeBeforeExplosion;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosionEffect;

    private RadiusDetectionController _radiusDetectionController;
    private ExplosionController _explosionController;
    private CompositeController _controllers;

    public void Detected()
    {
        _explosionController.Explode();
    }

    private void Awake()
    {
        InitializeControllers();
        _controllers.Enable();
    }

    private void InitializeControllers()
    {
        _radiusDetectionController = new(this, _detectionRadius, transform);
        _explosionController = new(_timeBeforeExplosion, transform, _detectionRadius, _explosionEffect , _damage);

        _controllers = new CompositeController(_radiusDetectionController, _explosionController);
    }

    private void Update()
    {
        _controllers.Update(Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        ShowRadiusDetection();
    }

    private void ShowRadiusDetection()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _detectionRadius);
    }
}
