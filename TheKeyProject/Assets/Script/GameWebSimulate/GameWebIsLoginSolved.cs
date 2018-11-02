using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWebIsLoginSolved : MonoBehaviour {
    public GameObject login;
    public GameObject information;

    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameManager.instance;
        if(gameManager.benGameLoggedIn)
        {
            Destroy(login);
            information.SetActive(true);
        }
	}
}
