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
    public float MaxHitPoints
    {
        get { return maxHitPoints; }
        set { maxHitPoints = value; }
    }

    // The Hitpoints that the chracter starts with
    private float startingHitPoints;
    public float StartingHitPoints
    {
        get { return startingHitPoints; }
        set { startingHitPoints = value; }
    }

    // Kill the character
    public virtual void KillCharacter()
    {
        Destroy(gameObject);
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

