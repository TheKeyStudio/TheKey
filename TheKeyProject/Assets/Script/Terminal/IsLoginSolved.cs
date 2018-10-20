﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLoginSolved : MonoBehaviour {
    public GameObject terminalLogin;
    public GameObject terminalUI;
    public int stage;
    public int level;

    GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameManager.instance;
        if(level <= gameManager.TerminalLogin)
        {
            Destroy(terminalLogin);
            terminalUI.SetActive(true);
        }
	}
}
