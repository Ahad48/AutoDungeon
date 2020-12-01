using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="FacingDirection")]
public class FacingDirection : ScriptableObject
{
    public enum currentlyFacing
    {
        up,
        down,
        left,
        right
    }
    public currentlyFacing CurrentlyFacing;
}
