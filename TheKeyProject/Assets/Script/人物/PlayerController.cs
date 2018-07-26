using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRigid2D;
    private Animator playerAnimator;
    private bool facingRight = true;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    [SerializeField] private float horizontalDirection = 0f;
    private Vector3 m_Velocity = Vector3.zero;

    public float runSpeed = 100f;
    public Interactable focus;

    [Header("目前的水平數度")]
    public float speedX;
    [Header("目前的垂直數度")]
    public float speedY;
    
    [Range(500, 1000)]
    public float yForce = 800f;

    [Header("感應地板的距離")]
    [Range(0, 0.5f)]
    public float distance;

    [Header("偵測地板的射線起點")]
    public Transform groundCheck;

    [Header("地面圖層")]
    public LayerMask groundLayer;

    public bool grounded;
    public bool jump;

    // Use this for initialization
    void Awake ()
    {
        playerRigid2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        horizontalDirection = Input.GetAxis("Horizontal") * runSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        horizontalDirection *= Time.fixedDeltaTime;
        if (GameManager.instance.CanMove)
        {
            MoveX();
            Jump();
            jump = false;
            playerAnimator.SetBool("Jump", !grounded);
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
    
    public void MoveX()
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
        playerAnimator.SetFloat("Horizontal", Math.Abs(Input.GetAxis("Horizontal")));
    }
    

    void Jump()
    {
        if (IsGrounded && jump)
        {
            playerRigid2D.AddForce(new Vector2(0f, yForce));
            playerAnimator.SetBool("Jump", true);
        }
    }
    
    
    //在玩家的底部射一條很短的射線 如果射線有打到地板 代表踩著地板
    bool IsGrounded
    {
        get
        {
            grounded = GetComponent<CircleCollider2D>().IsTouchingLayers(groundLayer);
            return grounded;
            /*
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);
            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            return grounded;
            */

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
}
