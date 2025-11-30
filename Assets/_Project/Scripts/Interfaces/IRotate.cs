using UnityEngine;

public interface IRotate
{
   Vector3 CurrentPositionTarget { get; }

    void SetLookAtPosition(Vector3 point);
}
