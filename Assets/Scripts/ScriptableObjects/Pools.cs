using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scriptable object script for helath pool and mana pool
/// </summary>
[CreateAssetMenu(menuName = "Pool")]
public class Pools : ScriptableObject
{
    [SerializeField]
    float value;
    public float Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public enum poolType
    {
        health,
        mana
    }

    [SerializeField]
    poolType itemPoolType = poolType.health;
    public poolType ItemPoolType
    {
        get { return itemPoolType; }
    }
}
