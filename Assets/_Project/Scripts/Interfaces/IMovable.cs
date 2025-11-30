using UnityEngine;

public interface IMovable
{
    Vector3 CurrentPositionTarget { get; }
    Vector3 CurrentDirectionToTarget { get; }

    void MoveTo(Vector3 point);
}
