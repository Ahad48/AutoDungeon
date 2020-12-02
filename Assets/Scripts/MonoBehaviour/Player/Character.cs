using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>An abstract class character, stores basic details and has abstract functions related to it</para>
/// </summary>
public abstract class Character : MonoBehaviour
{
    
    // The maximum hit points of a character
    [SerializeField]
    private float maxHitPoints = 0.0f;
    #region maxhitpoints get
    public float MaxHitPoints
    {
        get { return maxHitPoints; }
    }
    #endregion

    // The maximun mana points of a character
    [SerializeField]
    private float maxManaPoints = 0.0f;
    #region maxmanapoints get
    public float MaxManaPoints
    {
        get { return maxManaPoints; }
    }
    #endregion

    // The Hitpoints that the chracter starts with
    [SerializeField]
    private float startingHitPoints = 0.0f;
    #region starting hitpoints
    public float StartingHitPoints
    {
        get { return startingHitPoints; }
    }
    #endregion

    // The mana points that the character starts with
    [SerializeField]
    private float startingManaPoints = 0.0f;
    #region staring manpoints get
    public float StartingManaPoints
    {
        get { return startingManaPoints; }
    }
    #endregion

    // A enum for getting where the character is facing
    public enum currentlyFacing
    {
        up,
        down,
        left,
        right
    }

    // Kill the character
    public virtual void KillCharacter()
    {
        gameObject.SetActive(false);
    }

    // Is called when the object gets enables
    private void OnEnable()
    {
        ResetCharacter();
    }

    // Abstract function reset character
    public abstract void ResetCharacter();

    // A coroutine for damaging the character
    public abstract IEnumerator DamageCharacter(int damage, float interval);
}

