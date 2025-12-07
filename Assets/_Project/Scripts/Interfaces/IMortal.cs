using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMortal
{
    bool IsDead { get; }
    void Die();
}
