using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class for the scriptable objects items
/// </summary>
public class Consumables : MonoBehaviour
{
    [SerializeField]
    Item item = null;
    #region item get
    public Item Item
    {
        get { return item; }
    }
    #endregion
}
