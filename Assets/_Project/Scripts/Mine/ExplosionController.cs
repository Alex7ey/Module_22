using UnityEngine;

public class ExplosionController : Controller
{
    private float _timeBeforeExplosion;
    private float _timer;
    private bool _IsExploding;
    private bool _IsDestroyed;
    private ParticleSystem _particleEffect;
    private Transform _transform;
    private float _radiusExplode;
    private int _damage;

    public ExplosionController(float timeBeforeExplosion, Transform transform, float radiusExplode, ParticleSystem particleEffect, int damage)
    {
        _timeBeforeExplosion = timeBeforeExplosion;
        _transform = transform;
        _radiusExplode = radiusExplode;
        _particleEffect = particleEffect;
        _damage = damage;
    }

    public void Explode() => _IsExploding = true;

    protected override void UpdateLogic(float deltaTime)
    {
        if (_IsExploding && _IsDestroyed == false)
        {
            _timer += deltaTime;
            if (_timer >= _timeBeforeExplosion)
            {
                _particleEffect.transform.position = _transform.position;
                _particleEffect.Play();
                DealingDamage();
                _IsDestroyed = true;
                _transform.gameObject.SetActive(false);
            }
        }
    }

    private void DealingDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(_transform.position, _radiusExplode);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(_damage);
            }
        }
    }
}
