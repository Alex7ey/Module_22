using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MedkitSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private float _radius = 3;
    [SerializeField] private Medkit _medKit;
    [SerializeField] private Transform _targetPosition;

    private bool _isActive;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            _isActive = !_isActive;

        if (_isActive && _coroutine == null)
            _coroutine = StartCoroutine(ProccesSpawn());

        if (_isActive == false && _coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator ProccesSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnCooldown);
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 spawnPosition = _targetPosition.position + GetSpawnPosition();

        Instantiate(_medKit, spawnPosition, Quaternion.identity, transform);
    }

    private Vector3 GetSpawnPosition()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);

        float x = _radius * Mathf.Cos(angle);
        float y = _radius * Mathf.Sin(angle);

        return new Vector3(x, 0, y);
    }
}
