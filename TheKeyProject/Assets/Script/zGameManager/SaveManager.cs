using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Load(); 
        }
    }

    public static void Save()
    {
        GameManager gameManager = GameManager.instance;
        GameManagerData gameManagerData = gameManager.SaveGame();
        SaveSystem.Save<GameManagerData>("gm.ray", gameManagerData);
    }

    public static void Load()
    {
        GameManager gameManager = GameManager.instance;
        GameManagerData gameManagerData = SaveSystem.Load<GameManagerData>("gm.ray");
        gameManager.LoadGame(gameManagerData);
    }
}
