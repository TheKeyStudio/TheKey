using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRigid2D;
    private Animator playerAnimator;
    private bool canMove = true;
    private bool autoMoveing = false;
    
    [Range(300, 1000)]
    public float yForce = 500f;
    
    public Transform groundCheck;
    [Range(0, 0.5f)]
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    public bool grounded;
    public bool jump;

    private PlayerState playerState;
    private PlayerMotor playerMotor;

    void Awake ()
    {
        playerRigid2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerMotor = GetComponent<PlayerMotor>();

        playerState = new Normal(this);
    }

    private void Start()
    {
    }

    void Update ()
    {
        if (Input.GetButton("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        Move();
        SetJumpAnimation(!grounded);
    }
    
    public void Move()
    {
        playerMotor.Move();
        playerState.Move();
    }
    

    public void SetMoveAnimation(bool flag)
    {
        playerAnimator.SetBool("Move", flag);
    }

    public void SetJumpAnimation(bool flag)
    {
        playerAnimator.SetBool("Jump", flag);
    }

    void Jump()
    {
        if (grounded && jump)
        {
            playerRigid2D.AddForce(new Vector2(0f, yForce));
            playerAnimator.SetBool("Jump", true);
            jump = false;
        }
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

    public PlayerState PlayerState
    {
        set
        {
            playerState = value;
        }
    }

    public PlayerMotor PlayerMotor
    {
        get
        {
            return playerMotor;
        }
    }
    
}
