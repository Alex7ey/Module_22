using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MovementNavMeshAgentController
{
    private NavMeshAgent _agent;

    public MovementNavMeshAgentController(NavMeshAgent agent, float movementSpeed, Vector3 startPosition)
    {
        _agent = agent;

        SetMovePoint(startPosition);
        ConfigureNavMeshAgent(movementSpeed);
    }

    public Vector3 CurrentPositionTarget { get; private set; }

    public void SetMovePoint(Vector3 point)
    {
        CurrentPositionTarget = point;
        _agent.SetDestination(CurrentPositionTarget);
    }

    public bool IsValidPath(Vector3 point)
    {
        NavMeshPath path = new();
        _agent.CalculatePath(point, path);

        return path.status == NavMeshPathStatus.PathComplete;
    }

    private void ConfigureNavMeshAgent(float movementSpeed)
    {
        _agent.speed = movementSpeed;
    }
}
