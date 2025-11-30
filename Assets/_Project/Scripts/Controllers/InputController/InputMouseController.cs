using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouseController : Controller
{
    public bool IsMoveCommand { get; private set;}

    private const int LeftMouseButton = 0;

    protected override void UpdateLogic(float deltaTime)
    {
        IsMoveCommand = Input.GetMouseButtonDown(LeftMouseButton);
    }
}
