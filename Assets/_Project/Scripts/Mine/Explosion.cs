using UnityEngine;

public class Explosion
{
    private readonly float _timeBeforeExplosion;
    private readonly ParticleSystem _particleEffect;
    private readonly Transform _transform;
    private readonly float _radiusExplode;
    private readonly int _damage;

    private float _timer;
    private bool _isExploding;
    private bool _isDestroyed;

    public Explosion(float timeBeforeExplosion, Transform transform, float radiusExplode, ParticleSystem particleEffect, int damage)
    {
        _timeBeforeExplosion = timeBeforeExplosion;
        _transform = transform;
        _radiusExplode = radiusExplode;
        _particleEffect = particleEffect;
        _damage = damage;
    }

    public void Explode() => _isExploding = true;

    public void Update(float deltaTime)
    {
        ProcessExplosionCountdown(deltaTime);    
    }

    private void ProcessExplosionCountdown(float deltaTime)
    {
        if (_isExploding && _isDestroyed == false)
        {
            _timer += deltaTime;
            if (_timer >= _timeBeforeExplosion)
            {
                ExecuteExplosion();
                _isDestroyed = true;
            }
        }
    }

    private void PlayExplossionEffect()
    {
        _particleEffect.transform.position = _transform.position;
        _particleEffect.Play();
    }

    private void ExecuteExplosion()
    {
        PlayExplossionEffect();
        DealDamage();
        DisableObject();
    }

    private void DisableObject() => _transform.gameObject.SetActive(false);

    private void DealDamage()
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
