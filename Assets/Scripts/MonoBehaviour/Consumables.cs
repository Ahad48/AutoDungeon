using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
