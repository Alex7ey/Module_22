using UnityEngine;

public class DestinationMarker : MonoBehaviour
{
    [SerializeField] private GameObject _marker;
    [SerializeField] private Character _character;

    private Vector3 _targetPosition;

    private const float CollectionDistance = 0.5f;

    private void Awake()
    {
        _targetPosition = _character.transform.position;
        DisableMarker();
    }

    private void Update()
    {
        if (IsTargetReached())
        {
            DisableMarker();
            return;
        }

        if (_targetPosition != _character.CurrentPositionTarget)
        {
            SetMarkerPosition();
            EnableMarker();
        }
    }

    private void SetMarkerPosition()
    {
        _marker.transform.position = _character.CurrentPositionTarget;
        _targetPosition = _character.CurrentPositionTarget;

        EnableMarker();
    }

    private void EnableMarker() => _marker.SetActive(true);

    private void DisableMarker() => _marker.SetActive(false);

    private bool IsTargetReached() => (_marker.transform.position- _character.CurrentPosition).magnitude <= CollectionDistance;
}
