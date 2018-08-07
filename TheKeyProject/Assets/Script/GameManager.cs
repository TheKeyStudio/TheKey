using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool game1 = false;                  //第一階段的關卡 全部破完 才能通往下一關;
    public int stage1 = 0;
    public bool dark;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            dark = true;
            DontDestroyOnLoad(this);
            Debug.Log(game1);
            Debug.Log("Dark: " + dark);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }

   

}
