using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
/// <summary>
/// Scriptable object of item or pickups
/// </summary>
public class Item : ScriptableObject
{
    [SerializeField]
    float quantity = 0.0f;
    #region quantity get
    public float Quantity
    {
        get { return quantity; }
    }
    #endregion

    [SerializeField]
    bool stackable = true;
    #region stackable get
    public bool Stackable
    {
        get { return stackable; }
    }
    #endregion

    public enum itemType
    {
        coin,
        heart,
        mana
    }

    [SerializeField] itemType type = itemType.coin;
    #region type get
    public itemType Type
    {
        get { return type; }
    }
    #endregion
}
