using UnityEngine;

public class MoveRayCastController : Controller
{
    private IMovable _movable;

    public MoveRayCastController(IMovable movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Ground _))
            {
                _movable.MoveTo(hit.point);
            }
        }
    }
}
