using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovingController : Controller
{
    private NavMeshAgent _agent;
    private Transform _target;

    public NavMeshMovingController(NavMeshAgent agent, Transform target)
    {
        _agent = agent;
        _target = target;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _agent.SetDestination(_target.position);
    }
}
