//using UnityEngine;

//public class MoveInputController : Controller
//{
//    private Vector3 _currentDirection;
//    private IMovable _movable;

//    public MoveInputController(IMovable movable)
//    {
//        _movable = movable;
//    }

//    protected override void UpdateLogic(float deltaTime)
//    {
//        _currentDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

//        _movable.SetMoveDirection(_currentDirection);
//    }
//}
