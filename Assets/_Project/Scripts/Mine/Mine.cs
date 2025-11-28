using UnityEngine;

public class Mine : MonoBehaviour, IDetect
{
    [SerializeField] private float _radiusDetected;
    [SerializeField] private float _timeBeforeExplosion;
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _explosionEffect;

    private DetectController _radiusController;
    private ExplosionController _explosionController;
    private CompositeController _controllers;

    public void Detected()
    {
        _explosionController.Explode();
    }

    private void Awake()
    {
        _radiusController = new(this, _radiusDetected, transform);
        _explosionController = new(_timeBeforeExplosion, transform, _radiusDetected, _explosionEffect , _damage);

        _controllers = new CompositeController(_radiusController, _explosionController);
        _controllers.Enable();
    }

    private void Update()
    {
        _controllers.Update(Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, _radiusDetected);
    }
}
