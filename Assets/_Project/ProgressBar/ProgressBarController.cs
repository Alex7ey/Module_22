using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : Controller
{
    private Image _progressBar;
    private float _startValue;
    private bool _isFilling;

    public ProgressBarController(Image progressBar, float startValue)
    {
        _progressBar = progressBar;
        _startValue = startValue;
    }

    public void SetValueProgress(float value)
    {
        if (_isFilling)
        {
            _progressBar.transform.localScale = new Vector3(value / _startValue, _progressBar.transform.localScale.y, _progressBar.transform.localScale.z);
        }
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _isFilling = _progressBar.transform.localScale.x > 0;
    }
}
