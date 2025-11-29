using UnityEngine;

public class PointClickMovementController : Controller
{
    private readonly IMovable _movable;
    private readonly InputMouseController _mouseController;

    public PointClickMovementController(IMovable movable, InputMouseController mouseController)
    {
        _movable = movable;
        _mouseController = mouseController;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (_mouseController.IsMoveCommand && TryGetPoint(out Vector3 targetPoint))
        {
            _movable.MoveTo(targetPoint);
        }
    }

    private bool TryGetPoint(out Vector3 targetPoint)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Ground _))
            {
                targetPoint = hit.point;
                return true;
            }
        }
        targetPoint = Vector3.zero;
        return false;
    }
}
