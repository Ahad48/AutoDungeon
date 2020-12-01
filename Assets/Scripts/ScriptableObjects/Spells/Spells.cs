using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells")]
public class Spells : ScriptableObject
{
    [SerializeField]
    string spellName = null;
    public string SpellName
    {
        get { return spellName; }
    }

    [SerializeField]
    float spellQuantity = 0.0f;
    public float SpellQuantity
    {
        get { return spellQuantity; }
        set { spellQuantity = value; }
    }

    [SerializeField]
    float spellDuration = 0.0f;
    public float SpellDuration
    {
        get { return spellDuration; }
    }

    [SerializeField]
    GameObject spellPrefab = null;
    public GameObject SpellPrefab
    {
        get { return spellPrefab; }
    }

    [SerializeField]
    float spellSpawnDistance = 0.0f;
    public float SpellSpawnDistance
    {
        get { return spellSpawnDistance; }
        set { spellSpawnDistance = value; }
    }
    
    public enum SpellType{
        attack,
        boost,
        defense
    }

    [SerializeField]
    SpellType type = SpellType.attack;
    public SpellType Type
    {
        get { return type; }
    }

    [Header("If attack spell")]

    [SerializeField]
    public float spellDamage = 0.0f;
    

}
