using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolBar : MonoBehaviour
{
    [SerializeField] Pools poolsAmount = null;
    [SerializeField] Image poolBar = null;
    Player character = null;
    public Player Character
    {
        set { character = value; }
    }
    float maxHitPoints;

    // Start is called before the first frame update
    void Start()
    {
        maxHitPoints = character.MaxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (character != null)
        {
            poolBar.fillAmount = poolsAmount.Value / maxHitPoints;
        }
    }
}
