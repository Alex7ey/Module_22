using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthSystem 
{
    public bool IsAlive { get; }
    public bool IsTakeDamage { get; }
    public int CurrentHealth { get; }
    public int MaxHealth { get; }
}
