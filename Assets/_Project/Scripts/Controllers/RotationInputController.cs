using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInputController : Controller
{
    private IRotate _rotatable;
    private IMovable _movable;

    public RotationInputController(IRotate rotate, IMovable movable)
    {
        _rotatable = rotate;
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _rotatable.RotationTo(_movable.CurrentDirectionToTarget);
    }
}
