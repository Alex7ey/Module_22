using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private DestinationMarker _destinationMarker;
    [SerializeField] private InputExample _inputExample;

    private void Awake()
    {
        Character character = Instantiate(_characterPrefab, _spawnPoint.position, _spawnPoint.rotation);
        HealthSystem healthSystem = character.GetComponent<HealthSystem>();
        ViewCharacter viewCharacter = character.GetComponent<ViewCharacter>();

        InitializeComponents(healthSystem, viewCharacter, character);
    }

    private void InitializeComponents(HealthSystem healthSystem, ViewCharacter viewCharacter, Character character)
    {
        viewCharacter.Initialize(healthSystem);
        _healthBar.Initialize(healthSystem);
        _destinationMarker.Initialize(character);
        _virtualCamera.Follow = character.transform;
        _inputExample.Initialize(new PointClickMovementController(character));
    }
}
