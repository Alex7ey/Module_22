using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class DirectionalMover
{
    private readonly NavMeshAgent _agent;

    public DirectionalMover(NavMeshAgent agent, float movementSpeed)
    {
        _agent = agent;
        _agent.speed = movementSpeed;
        CurrentPositionTarget = agent.transform.position;
    }

    public Vector3 CurrentPositionTarget { get; private set; }

    public void SetMovePoint(Vector3 point)
    {
        if (IsValidPath(point) == false)
            return;
        
        CurrentPositionTarget = point;
        _agent.SetDestination(CurrentPositionTarget);
    }

    public bool IsValidPath(Vector3 point)
    {
        NavMeshPath path = new();
        _agent.CalculatePath(point, path);

        return path.status == NavMeshPathStatus.PathComplete;
    }
}
