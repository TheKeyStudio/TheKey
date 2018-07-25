using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using TMPro;

public class Test1 : MonoBehaviour {
    GameManager gameManager;
    public TMP_InputField Input;
    
    private string character;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    public void Iscorrest() {
        character = Input.text;
        if (character == "hack into")
        {
            
            Flowchart.BroadcastFungusMessage("答對了");
            gameManager.stage1 += 1;
            gameObject.SetActive(false);
        }
        else
        {
            Flowchart.BroadcastFungusMessage("答錯了");
        }
    }
}
