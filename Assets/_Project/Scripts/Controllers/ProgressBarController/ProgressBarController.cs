using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController
{
    private readonly Image _progressBar;
    private readonly float _maxValue;

    private const float MinValue = 0; 

    public ProgressBarController(Image progressBar, float maxValue)
    {
        _progressBar = progressBar;
        _maxValue = maxValue;
    }

    public void SetValueProgress(float currentValue)
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
