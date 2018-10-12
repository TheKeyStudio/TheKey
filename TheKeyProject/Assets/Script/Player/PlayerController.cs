using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRigid2D;
    private Animator playerAnimator;
    private bool facingRight = true;
    public Vector3 m_Velocity = Vector3.zero;
    private bool canMove = true;
    private bool autoMoveing = false;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private float horizontalDirection = 0f;

    public float runSpeed = 100f;
    public Interactable focus;
    
    [Range(300, 1000)]
    public float yForce = 500f;
    
    public Transform groundCheck;
    [Range(0, 0.5f)]
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    public bool grounded;
    public bool jump;

    
    void Awake ()
    {
        playerRigid2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
	
	void Update ()
    {
        if (!autoMoveing)
            SetHorizontalDirection(Input.GetAxis("Horizontal"));
        
        if (Input.GetButton("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            autoMoveing = true;
        }
    }

    private void FixedUpdate()
    {
        horizontalDirection *= Time.fixedDeltaTime;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        playerAnimator.SetBool("Jump", !grounded);
        if (canMove)
        {
            MoveX(horizontalDirection);
            Jump();
            jump = false;
        }
        else
        {
            SetMoveAnimation(false);
        }

        if (Math.Abs(Input.GetAxis("Horizontal")) < 0.1 && !autoMoveing)
        {
            SetMoveAnimation(false);
        }

        if (Math.Abs(Input.GetAxis("Horizontal")) > 0.1)
        {
            autoMoveing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            SetFocus(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFocus();
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefoucused();
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if(focus!=null)
            focus.OnDefoucused();
        focus = null;
    }
    
    public void MoveX(float horizontal)
    {
        Vector3 targetVelocity = new Vector2(horizontal * 10f, playerRigid2D.velocity.y);
        playerRigid2D.velocity = Vector3.SmoothDamp(playerRigid2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        // If the input is moving the player right and the player is facing left...
        if (horizontal > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontal < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }
        SetMoveAnimation(true);
    }

    void SetMoveAnimation(bool flag)
    {
        playerAnimator.SetBool("Move", flag);
    }
    
    void Jump()
    {
        if (grounded && jump)
        {
            playerRigid2D.AddForce(new Vector2(0f, yForce));
            playerAnimator.SetBool("Jump", true);
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

    public void DeactiveMove()
    {
        playerRigid2D.velocity = Vector3.zero;
        canMove = false;
    }

    public void ActiveMove()
    {
        canMove = true;
    }

    public bool CanPlayerMove
    {
        get
        {
            return canMove;
        }
    }

    public bool AutoMoveing
    {
        get
        {
            return autoMoveing;
        }
        set
        {
            autoMoveing = value;
        }
    }

    public void SetHorizontalDirection(float horizontal)
    {
        horizontalDirection = horizontal * runSpeed;
    }
}
