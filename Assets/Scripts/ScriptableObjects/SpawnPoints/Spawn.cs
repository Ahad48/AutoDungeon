using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A Spawn Scriptable object which gives the needed room location
/// </summary>
[CreateAssetMenu(menuName = "Spawn")]
public class Spawn : ScriptableObject
{
    /// <summary>
    /// An enum of the various door location required each spwan point will have one door associated with it
    /// </summary>
    public enum neededDoorDirection
    {
        top,
        bottom,
        left,
        right,
        center
    }

    public neededDoorDirection doorDirection;
}
