using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private Rigidbody2D playerRigid2D;
    private bool facingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private float horizontalDirection = 0f;

    [SerializeField] private float runSpeed = 100f;
    
    [Range(300, 800)] [SerializeField] private float yForce = 500f;

    public Transform groundCheck;
    [Range(0, 0.5f)] [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool grounded;

    void Awake()
    {
        playerRigid2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontalDirection *= Time.fixedDeltaTime;

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    public bool IsGrounded()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        return grounded;
    }

    public void Jump()
    {
        if (grounded)
        {
            playerRigid2D.AddForce(new Vector2(0f, yForce));
        }
    }

    public void Move()
    {
        Vector3 targetVelocity = new Vector2(horizontalDirection * 10f, playerRigid2D.velocity.y);
        playerRigid2D.velocity = Vector3.SmoothDamp(playerRigid2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        // If the input is moving the player right and the player is facing left...
        if (horizontalDirection > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalDirection < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetHorizontalDirection(float horizontal)
    {
        horizontalDirection = horizontal * runSpeed;
    }
}
