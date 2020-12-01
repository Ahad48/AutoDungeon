using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Pools health = null;
    [SerializeField] Pools mana = null;
    [SerializeField] PoolBar healthBar = null;
    [SerializeField] PoolBar manaBar = null;

    public enum currentlyFacing
    {
        up,
        down,
        left,
        right
    }

    public static currentlyFacing Facing = currentlyFacing.right;

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
        if (collision.CompareTag("Item"))
        {
            print("Item");
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
    }

    public override void ResetCharacter()
    {
        healthBar.Character = this;
        manaBar.Character = this;
    }

    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true) {
            health.Value -= damage;

            if (health.Value <= float.Epsilon)
            {
                print("health died");
                KillCharacter();
                break;
            }

            if (health.Value > float.Epsilon)
            {
                print("wait for seconds: " + interval);
                yield return new WaitForSeconds(interval);
            }

            else
            {
                print("else");
                break;
            }
        }
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
