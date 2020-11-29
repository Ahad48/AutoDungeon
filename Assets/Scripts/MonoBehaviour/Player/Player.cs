using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Pools health = null;
    [SerializeField] Pools mana = null;
    [SerializeField] PoolBar healthBar = null;
    [SerializeField] PoolBar manaBar = null;
    // Start is called before the first frame update
    void Start()
    {
        health.Value = StartingHitPoints;
        mana.Value = StartingManaPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool shouldDisappear = false;
        Item hitObject = collision.GetComponent<Consumables>().Item;

        if(hitObject.Type == Item.itemType.coin)
        {
            print("Coin Collected");
            shouldDisappear = true;
        }

        else if(hitObject.Type == Item.itemType.heart)
        {
            shouldDisappear = AdjustHitPoints(hitObject.Quantity);
            //print(health.Value);
        }

        else if (hitObject.Type == Item.itemType.mana)
        {
            shouldDisappear = AdjustManaPoints(hitObject.Quantity);
            //print(mana.Value);
        }

        if(shouldDisappear)
            collision.gameObject.SetActive(false);
    }

    public override void ResetCharacter()
    {
        print("ehhhhh");
        healthBar.Character = this;
        manaBar.Character = this;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        throw new System.NotImplementedException();
    }

    bool AdjustHitPoints(float amount)
    {
        if (health.Value < MaxHitPoints)
        {
            health.Value += amount;

            if (health.Value > MaxHitPoints)
            {
                health.Value = MaxHitPoints;
            }
            return true;
        }
        else
            return false;
    }

    bool AdjustManaPoints(float amount)
    {
        if (mana.Value < MaxManaPoints)
        {
            mana.Value += amount;

            if (mana.Value > MaxManaPoints)
            {
                mana.Value = MaxManaPoints;
            }
            return true;
        }

        else
            return false;
    }
}
