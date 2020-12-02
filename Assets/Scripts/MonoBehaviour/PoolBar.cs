using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A script for updating the pool bars (health bar and mana bar)
/// </summary>
public class PoolBar : MonoBehaviour
{
    // The scriptable object pools (health or mana)
    [SerializeField] Pools poolsAmount = null;

    // The fill image of the bar
    [SerializeField] Image poolBar = null;

    // The main player character
    [HideInInspector]
    Player character = null;
    #region character set
    public Player Character
    {
        set { character = value; }
    }
    #endregion

    // The max hitpoints of the character
    float maxHitPoints;

    // Start is called before the first frame update
    void Start()
    {
        // Store the max hitpoints of the character
        maxHitPoints = character.MaxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        // If the character is not empty update the pool bar
        if (character != null)
        {
            poolBar.fillAmount = poolsAmount.Value / maxHitPoints;
        }
    }
}
