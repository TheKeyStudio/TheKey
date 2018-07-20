using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D playerRigid2D;
    public float maxSpeed;
    public Interactable focus;

    [Header("目前的水平數度")]
    public float speedX;
    [Header("目前的垂直數度")]
    public float speedY;
    [Header("目前的水平方向")]
    public float horizontalDirection;

    [Range(10, 150)]
    public float xForce;
    [Range(500, 1000)]
    public float yForce;

    [Header("感應地板的距離")]
    [Range(0, 0.5f)]
    public float distance;

    [Header("偵測地板的射線起點")]
    public Transform groundCheck;

    [Header("地面圖層")]
    public LayerMask groundLayer;

    public bool grounded;

    // Use this for initialization
    void Start () {
        playerRigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.CanMove)
        {
            ControlSpeed();
            MoveX();
            Jump();
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

    public void ControlSpeed()
    {
        speedX = playerRigid2D.velocity.x;
        speedY = playerRigid2D.velocity.y;
        float newSpeedX = Mathf.Clamp(speedX, -maxSpeed, maxSpeed);
        playerRigid2D.velocity = new Vector2(newSpeedX, speedY);
    }

    public void MoveX()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        playerRigid2D.AddForce(new Vector2(xForce * horizontalDirection, 0));
    }

    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);

        }
    }

    void Jump()
    {
        if (IsGrounded && JumpKey)
        {
            playerRigid2D.AddForce(Vector2.up * yForce);
        }
    }
    
    
    //在玩家的底部射一條很短的射線 如果射線有打到地板 代表踩著地板
    bool IsGrounded
    {
        get
        {
            Vector2 start = groundCheck.position;
            Vector2 end = new Vector2(start.x, start.y - distance);
            Debug.DrawLine(start, end, Color.blue);
            grounded = Physics2D.Linecast(start, end, groundLayer);
            return grounded;

        }
    }
}
