using UnityEngine;

public class PointClickMovementController : Controller
{
    private readonly Character _movable;
    private const int LeftMouseButton = 0;

    public PointClickMovementController(Character movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Input.GetMouseButtonDown(LeftMouseButton) && TryGetPoint(out Vector3 targetPoint))
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
