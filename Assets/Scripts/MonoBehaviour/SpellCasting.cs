using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    [SerializeField]
    Spells[] spells = null;

    [SerializeField]
    FacingDirection direction = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            instantiateSpell(spells[0].SpellPrefab, transform, spells[0].SpellSpawnDistance, direction);
        }
    }

    void instantiateSpell(GameObject spellPrefab, Transform transform, float distance, FacingDirection direction)
    {
        Vector3 vectorDirection = Vector3.right;

        if (direction.CurrentlyFacing == FacingDirection.currentlyFacing.right)
        {
            vectorDirection = Vector3.right;
        }

        else if(direction.CurrentlyFacing == FacingDirection.currentlyFacing.left)
        {
            vectorDirection = Vector3.left;
        }

        else if (direction.CurrentlyFacing == FacingDirection.currentlyFacing.up)
        {
            vectorDirection = Vector3.up;
        }

        else if (direction.CurrentlyFacing == FacingDirection.currentlyFacing.down)
        {
            vectorDirection = Vector3.down;
        }

        Instantiate(spellPrefab, transform.position +  vectorDirection * distance, Quaternion.identity);
    }
}
