using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int money;
    public bool game1 = false;                  //第一階段的關卡 全部破完 才能通往下一關;
    public int stage1 = 0;

    private bool canMove = true;

    public bool CanMove
    {
        get
        {
            return canMove;
        }
    }

    public void playerStop()
    {
        canMove = false;
    }

    public void playerMove()
    {
        canMove = true;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            name = "最初的遊戲管理物件";
            money = 0;
            
            Debug.Log(game1);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

        
    }

    
}
