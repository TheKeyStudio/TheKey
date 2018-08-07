using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Darkspace : MonoBehaviour {
    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameManager.instance;
	}
	
	// Update is called once per frame
	public void Begin ()
    {
        Debug.Log("Begin");
        
        if (gameManager.dark)
        {
            Debug.Log("開始");
            Flowchart.BroadcastFungusMessage("開始");
            gameManager.dark = false;
        }
        else
        {
            
            Debug.Log("開門");
            Flowchart.BroadcastFungusMessage("開門");
        }
	}
}
