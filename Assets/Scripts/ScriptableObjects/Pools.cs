using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scriptable object script for helath pool and mana pool
/// </summary>
[CreateAssetMenu(menuName = "Pool")]
public class Pools : ScriptableObject
{
    public float value;
    public enum poolType
    {
        health,
        mana
    }
    public poolType itemPoolType;
}
