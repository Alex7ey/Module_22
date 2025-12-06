using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Controller _characterController;

    private void Awake()
    {
        _characterController = new PointClickMovementController(_character);
        _characterController.Enable();
    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
    }
}
