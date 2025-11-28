using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : Controller
{

    public bool IsLeftMouseButtonDown;

    protected override void UpdateLogic(float deltaTime)
    {
        UpdateValue();

        if (Input.GetMouseButtonDown(0))
        {
            IsLeftMouseButtonDown = true;
        }      
    }

    private void UpdateValue()
    {
        IsLeftMouseButtonDown = false;
    }
}
