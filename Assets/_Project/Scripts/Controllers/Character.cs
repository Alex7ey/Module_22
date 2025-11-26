using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private NavMeshAgent _agent;

    private CompositeController _controller;

    private void Awake()
    {
        _controller = new(new NavMeshMovingController(_agent, _targetPosition), new RotatorController(transform, _targetPosition, _rotationSpeed));
        _controller.Enable();
    }

    private void Update()
    {
        _controller.Update(Time.deltaTime);
    }
}
