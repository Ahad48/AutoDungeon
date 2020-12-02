using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Pools health = null; // The health of the character scriptable object pools
    [SerializeField] Pools mana = null; // The mana of the Character Scriptable object pools
    [SerializeField] PoolBar healthBar = null; // The health bar of the character
    [SerializeField] PoolBar manaBar = null;  // The mana bar of the character

    public static currentlyFacing Facing = currentlyFacing.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collides with an item
        if (collision.CompareTag("Item"))
        {
            bool shouldDisappear = false; // Check if the object should disappear

            // The hit item stored
            Item hitObject = collision.GetComponent<Consumables>().Item;

            // If the item is coin add to the inventory
            // TO-DO add inventory
            if(hitObject.Type == Item.itemType.coin)
            {
                print("Coin Collected");
                shouldDisappear = true;
            }

            // If collides with a helath pickup
            else if(hitObject.Type == Item.itemType.heart)
            {
                // Adjust the hitpoints of the character
                shouldDisappear = AdjustHitPoints(hitObject.Quantity);
                //print(health.Value);
            }

            // If collides with a mana pickup
            else if (hitObject.Type == Item.itemType.mana)
            {
                shouldDisappear = AdjustManaPoints(hitObject.Quantity);
                //print(mana.Value);
            }

            // check if the object should disappear and set active as false
            if(shouldDisappear)
                collision.gameObject.SetActive(false);
        }
    }


    public override void ResetCharacter()
    {
        // Set the starting helath and mana points
        health.Value = StartingHitPoints;
        mana.Value = StartingManaPoints;

        // Set the helathbar and the mana bar to this character
        healthBar.Character = this;
        manaBar.Character = this;
    }
    /// <summary>
    /// Damages the player by reducing the health and if the helath goes below 0 kills the character
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="interval"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Adjusts the hitpoints of the chacter used for adding the helath point of the character 
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>bool if the pickup should be deactivated</returns>
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

    /// <summary>
    /// Increases the mana of the character, adds the amount to the mana value points of the main character 
    /// </summary>
    /// <param name="amount"></param>
    /// <returns>bool if the pickup should be deactivated</returns>
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
