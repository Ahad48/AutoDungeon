using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; // The movement smoothning applied to the character

    [SerializeField]
    private float movementSpeed = 40; // The movement speed of the character

    #region Sprites based on direction
    [SerializeField]
    private Sprite front = null;

    [SerializeField]
    private Sprite back = null;

    [SerializeField]
    private Sprite right = null;

    [SerializeField]
    private Sprite left = null;
    #endregion

    [SerializeField]
    FacingDirection direction = null; // Scriptable object the direction of the character

    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    float moveHorizontal;
    float moveVertical;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CharacterMovementInput();
        UpdateState();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Flip(Transform m_object)
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        m_object.transform.Rotate(0f, 180f, 0f);
    }

    /// <summary>
    /// Registers the input of the character movement
    /// </summary>
    void CharacterMovementInput()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    /// <summary>
    /// Moves the CHaracter in the direction registered by the moveCharacter function
    /// </summary>
    private void Move()
    {
        moveHorizontal *= Time.fixedDeltaTime;
        moveVertical *= Time.fixedDeltaTime;

        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(moveHorizontal, moveVertical);
        targetVelocity = targetVelocity.normalized;
        targetVelocity *= movementSpeed;

        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        //if (moveHorizontal > 0 && !m_FacingRight)
        //{
        //    // ... flip the player.
        //    Flip();
        //}
        //// Otherwise if the input is moving the player left and the player is facing right...
        //else if (moveHorizontal < 0 && m_FacingRight)
        //{
        //    // ... flip the player.
        //    Flip();
        //}
    }

    /// <summary>
    /// Updates te sprite of the character based on the movement also changes the sprite order based on the direction facing
    /// </summary>
    private void UpdateState()
    {
        Transform staff = transform.GetChild(0);

        if (moveHorizontal > 0)
        {
            spriteRenderer.sprite = right;
            spriteRenderer.sortingOrder = 0;
            direction.CurrentlyFacing = FacingDirection.currentlyFacing.right;
        }

        else if (moveHorizontal < 0)
        {
            spriteRenderer.sprite = left;
            spriteRenderer.sortingOrder = 2;
            direction.CurrentlyFacing = FacingDirection.currentlyFacing.left;
        }

        else if (moveVertical > 0)
        {
            spriteRenderer.sprite = back;
            spriteRenderer.sortingOrder = 2;
            direction.CurrentlyFacing = FacingDirection.currentlyFacing.up;
        }

        else if (moveVertical < 0)
        {
            spriteRenderer.sprite = front;
            spriteRenderer.sortingOrder = 0;
            direction.CurrentlyFacing = FacingDirection.currentlyFacing.down;
        }

        FlipStaff(staff);
    }

    /// <summary>
    /// Flips the staff based on the diction of movement
    /// </summary>
    /// <param name="staff"></param>
    void FlipStaff(Transform staff)
    {
        // If the input is moving the player right and the player is facing left...
        if ((direction.CurrentlyFacing == FacingDirection.currentlyFacing.right && !m_FacingRight)
            || direction.CurrentlyFacing== FacingDirection.currentlyFacing.up && !m_FacingRight)
        {
            // ... flip the player.
            Flip(staff);
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if ((direction.CurrentlyFacing == FacingDirection.currentlyFacing.left && m_FacingRight)
            || (direction.CurrentlyFacing == FacingDirection.currentlyFacing.down && m_FacingRight))
        {
            // ... flip the player.
            Flip(staff);
        }

        //else if((direction.CurrentlyFacing == FacingDirection.currentlyFacing.left && m_FacingRight ))
    }

}
