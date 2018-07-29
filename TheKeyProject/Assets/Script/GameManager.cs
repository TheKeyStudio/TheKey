using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool game1 = false;                  //第一階段的關卡 全部破完 才能通往下一關;
    public int stage1 = 0;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            Debug.Log(game1);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }

    /*
    public bool CanPlayerMove
    {
        get
        {
            return canPlayerMove;
        }
    }
    public void DeactiveMove()
    {
        canPlayerMove = false;
    }

    public void ActiveMove()
    {
        canPlayerMove = true;
    }
    */
}
