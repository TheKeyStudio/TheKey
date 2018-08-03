using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Darkspace : MonoBehaviour {
    GameManager gameManager;
	// Use this for initialization
	void Awake () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	public void begin ()
    {
        if (!gameManager.darkspace)
        {
            Flowchart.BroadcastFungusMessage("開始");
            gameManager.darkspace = true;
        }
	}
}
