using UnityEngine;

public interface IRotate
{
   Vector3 CurrentDirectionToTarget { get; }

    void SetLookAtDirection(Vector3 direction);
}
