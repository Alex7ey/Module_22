using UnityEngine;

public interface IRotate
{
   Vector3 CurrentDirectionToTarget { get; }

    void RotationTo(Vector3 direction);
}
