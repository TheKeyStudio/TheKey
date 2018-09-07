using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAuto : MonoBehaviour {

    public static PlayerAuto instance = null;
    [HideInInspector] public bool until = false;
    PlayerController playerController;
    float directionX;
    float deviation;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController.AutoMoveing)
        {
            if (transform.position.x > directionX + deviation)
            {
                playerController.SetHorizontalDirection(-1);
            }
            else if (transform.position.x < directionX - deviation)
            {
                playerController.SetHorizontalDirection(1);
            }
            else
            {
                until = true;
                playerController.AutoMoveing = false;
            }
        }
    }

    public void AutoMoveXTo(float directionX, float deviation)
    {
        playerController.AutoMoveing = true;
        until = false;
        this.directionX = directionX;
        this.deviation = deviation;
    }

    public bool IsAutoMoving()
    {
        return playerController.AutoMoveing;
    }
}
