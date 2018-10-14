using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRigid2D;
    private Animator playerAnimator;
    private bool canMove = true;
    public bool talking = false;

    public Flowchart flowChart;

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
    [SerializeField] private MouseInteractable focusing;

    public string playerStateName;

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
        playerStateName = playerState.GetType().ToString();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        Move();
        if(jump)
            Jump();
        SetJumpAnimation(!grounded);
    }
    
    public void Move()
    {
        playerMotor.Move();
        playerState.Move();
    }
    
    public void Interact()
    {
        talking = true;
        focusing.Interact();
        StartCoroutine(Talk());
    }

    IEnumerator Talk()
    {
        bool flowChartTalking = flowChart.GetBooleanVariable("Talking");
        while (talking || flowChartTalking)
        {
            flowChartTalking = flowChart.GetBooleanVariable("Talking");

            if (flowChartTalking && talking)
                talking = false;

            yield return null;
        }
        Debug.Log("Done talk");
        playerState.Interaction();
    }

    public void AutoMoveToX(float directionX, float deviation, MouseInteractable interactable)
    {
        this.focusing = interactable;
        playerState.AutoMoveToX(directionX, deviation);
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
            jump = false;
            playerRigid2D.AddForce(new Vector2(0f, yForce));
            playerAnimator.SetBool("Jump", true);
        }
    }

    public PlayerState PlayerState
    {
        set
        {
            Debug.Log("State: " + value.ToString());
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

    public void DeactiveMove()
    {
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
}
