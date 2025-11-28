using UnityEngine;
using UnityEngine.AI;

public class MovementController : Controller
{
    private NavMeshAgent _agent;
    private float _movementSpeed;

    public MovementController(NavMeshAgent agent, float movementSpeed)
    {
        _agent = agent;
        _movementSpeed = movementSpeed;
        _agent.speed = _movementSpeed;
    }

    public Vector3 CurrentDirectionToTaget { get; private set; }

    public void SetMoveDirection(Vector3 point) => CurrentDirectionToTaget = point;//можно прокинуть IMovable и от туда тырить направление

    protected override void UpdateLogic(float deltaTime)
    {
        if (CurrentDirectionToTaget != Vector3.zero)
        {
            _agent.isStopped = false;
            _agent.SetDestination(CurrentDirectionToTaget);
            return;
        }
        _agent.isStopped = true;
    }
}
