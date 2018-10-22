using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRigid2D;
    private Animator playerAnimator;
    
    public Flowchart flowChart;

    
    private PlayerState playerState;
    private PlayerMotor playerMotor;
    [SerializeField] private Interactable focusing;

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
        playerStateName = playerState.GetType().ToString();
        
        if (Input.GetButtonDown("Jump"))
        {
            playerState.Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
        SetJumpAnimation(!playerMotor.IsGrounded());
    }
    
    public void Move()
    {
        playerMotor.Move();
        playerState.Move();
    }

    public void Interact(Flowchart flowChart)
    {
        StartCoroutine(playerState.Interact(flowChart));
    }

    //For automove
    public void Interact()
    {
        Interact(flowChart);
    }

    //For trigger event
    public void TriggerEvent(Flowchart newflowChart, Interactable newFocus)
    {
        SetFocus(newFocus);
        Interact(newflowChart);
    }
    
    public void InteractTheFocusing()
    {
        focusing.Interact();
    }

    public void ReadBook()
    {
        playerState.ReadBook();
    }

    public void Enter(Interactable newFocus)
    {
        SetFocus(newFocus);
        Enter();
    }

    public void Enter()
    {
        playerState.Enter();
    }

    public void AutoMoveToX(float directionX, float deviation, Interactable interactable)
    {
        SetFocus(interactable);
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

    public void RemoveFocus()
    {
        focusing = null;
    }
    
    public void SetFocus(Interactable newFocus)
    {
        if(newFocus != focusing)
        {
            focusing = newFocus;
        }
    }
}
