using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scriptable object script for helath pool and mana pool
/// </summary>
[CreateAssetMenu(menuName = "Pool")]
public class Pools : ScriptableObject
{
    /// <summary>
    /// The value of the pool (Helath value or mana value)
    /// </summary>
    [SerializeField]
    float value;
    #region value get and set
    public float Value
    {
        get { return value; }
        set { this.value = value; }
    }
    #endregion

    /// <summary>
    /// Type of pool helath or mana stamina can be added
    /// </summary>
    public enum poolType
    {
        health,
        mana
    }

    [SerializeField]
    poolType itemPoolType = poolType.health;

    #region ItemPool type get and set
    public poolType ItemPoolType
    {
        get { return itemPoolType; }
    }
    #endregion
}
