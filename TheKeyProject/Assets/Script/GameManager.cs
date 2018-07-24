using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int money;
    public bool game1 = false;                  //第一階段的關卡 全部破完 才能通往下一關;
    public bool first_game1 = false;
    public bool first_game2 = false;
    public bool first_game3 = false;
    public bool first_game4 = false;
    public bool first_game5 = false;
    public bool first_game6 = false;
    public bool first_game7 = false;
    public bool first_game8 = false;
    public bool first_game9 = false;

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
