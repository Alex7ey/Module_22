using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealer 
{
    int HealAmount { get; }

    void Heal(IHealable healable);
}
