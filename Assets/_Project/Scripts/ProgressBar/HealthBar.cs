using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    private HealthSystem _healthSystem;

    private float _maxValue;
    private int _currentHealth;
    private const float MinValue = 0;

    public void Initialize(HealthSystem healthSystem)
    {
        _healthSystem = healthSystem;
        _maxValue = healthSystem.MaxHealth;
    }

    private void Update()
    {
        if(_currentHealth != _healthSystem.CurrentHealth)
        {
            SetValueProgress(_healthSystem.CurrentHealth);

            _currentHealth = _healthSystem.CurrentHealth;
        }
    }

    private void SetValueProgress(float currentValue)
    {
        if(_progressBar.type != Image.Type.Filled)
        {
            Debug.LogWarning("Image is not Filled type!");
            return;
        }

        float fillAmount = Mathf.InverseLerp(MinValue, _maxValue, currentValue);
        _progressBar.fillAmount = fillAmount;
    }
}
