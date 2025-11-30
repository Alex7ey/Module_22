using UnityEngine;

public class DestinationMarkerController : Controller
{
    private readonly GameObject _marker;
    private readonly Transform _playerTransform;

    private const float CollectionDistance = 0.5f;

    public DestinationMarkerController(GameObject marker, Transform playerTransform)
    {
        _marker = marker;
        _playerTransform = playerTransform;
        DisableMarker();
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (IsTargetReached())
            DisableMarker();
    }

    public void SetMarkerPosition(Vector3 targetPoint)
    {
        EnableMarker();
        _marker.transform.position = targetPoint;
    }


    private void EnableMarker() => _marker.SetActive(true);

    private void DisableMarker() => _marker.SetActive(false);

    private bool IsTargetReached() => Vector3.Distance(_playerTransform.position, _marker.transform.position) <= CollectionDistance;
}
