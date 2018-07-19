using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Player : MonoBehaviour {
    Rigidbody2D player2d;
    public GameManager gameManager;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    [Header("目前的水平數度")]
    public float speedX;

    [Header("目前的水平方向")]
    public float horizontalDirection;

    [Range(0, 150)]
    public float xForce;

    [Header("目前的垂直數度")]
    public float speedY;

    public float maxSpeed;

    public void ContrilSpeed()
    {
        speedX = player2d.velocity.x;
        speedY = player2d.velocity.y;
        float newSpeedX = Mathf.Clamp(speedX, -maxSpeed, maxSpeed);
        player2d.velocity = new Vector2(newSpeedX, speedY);
    }


    // Use this for initialization
    void Start()
    {
        player2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>水平數度</summary>
    void MonveMentX()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
        player2d.AddForce(new Vector2(xForce * horizontalDirection, 0));
    }

    [Header("垂直向上推力")]
    public float yForce;
    public bool JumpKey
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);

        }
    }

    void TryJump()
    {
        if (IsGround && JumpKey)
        {
            player2d.AddForce(Vector2.up * yForce);
        }
    }

    [Header("感應地板的距離")]

    [Range(0, 0.5f)]

    public float distance;

    [Header("偵測地板的射線起點")]
    public Transform groundCheck;

    [Header("地面圖層")]
    public LayerMask groundLayer;

    public bool grounded;
    //在玩家的底部射一條很短的射線 如果射線有打到地板 代表踩著地板

    bool IsGround
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
    

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CanMove)
        {
            MonveMentX();
            ContrilSpeed();
            TryJump();
        }
    }


    

}
