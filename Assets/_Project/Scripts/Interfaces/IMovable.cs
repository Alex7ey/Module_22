using UnityEngine;

public interface IMovable
{
    Vector3 CurrentPositionTarget { get; }
    Vector3 CurrentDirectionToTarget { get; }
    Vector3 CurrentPosition {  get; }

    void MoveTo(Vector3 point);
}
