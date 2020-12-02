using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The direction in which the character is facing
/// </summary>
[CreateAssetMenu(menuName ="FacingDirection")]
public class FacingDirection : ScriptableObject
{
    /// <summary>
    /// The enum of the various directions that the character can face
    /// </summary>
    public enum currentlyFacing
    {
        up,
        down,
        left,
        right
    }
    public currentlyFacing CurrentlyFacing;
}
