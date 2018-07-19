using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour {

    static GameManager instance;
    public int money;
    public bool game1 = false;

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
