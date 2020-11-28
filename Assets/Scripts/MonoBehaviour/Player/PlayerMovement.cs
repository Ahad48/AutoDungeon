using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

    [SerializeField]
    private float movementSpeed = 40;

    [SerializeField]
    private Sprite front = null;

    [SerializeField]
    private Sprite back = null;

    [SerializeField]
    private Sprite right = null;

    [SerializeField]
    private Sprite left = null;

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
        MoveCharacter();
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

    void MoveCharacter()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

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

    private void UpdateState()
    {
        Transform staff = transform.GetChild(0);

        if (moveHorizontal > 0)
        {
            spriteRenderer.sprite = right;
            spriteRenderer.sortingOrder = 0;
        }

        else if (moveHorizontal < 0)
        {
            spriteRenderer.sprite = left;
            spriteRenderer.sortingOrder = 2;
        }

        else if (moveVertical > 0)
        {
            spriteRenderer.sprite = back;
            spriteRenderer.sortingOrder = 2;
        }

        else if (moveVertical < 0)
        {
            spriteRenderer.sprite = front;
            spriteRenderer.sortingOrder = 0;
        }

        // If the input is moving the player right and the player is facing left...
        if ((moveHorizontal > 0 && !m_FacingRight) || (moveVertical > 0 && !m_FacingRight))
        {
            // ... flip the player.
            Flip(staff);
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if ((moveHorizontal < 0 && m_FacingRight) || (moveVertical < 0 && m_FacingRight))
        {
            // ... flip the player.
            Flip(staff);
        }
    }

}
