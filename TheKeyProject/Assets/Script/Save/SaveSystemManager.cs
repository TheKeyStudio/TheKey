using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystemManager : MonoBehaviour {
    [SerializeField] private static string fileName = "gm.ray";

    public static void Save()
    {
        GameManager gameManager = GameManager.instance;
        GameManagerData gameManagerData = gameManager.SaveGame();
        SaveSystem.Save<GameManagerData>(fileName, gameManagerData);
    }

    public static void Load()
    {
        GameManager gameManager = GameManager.instance;
        GameManagerData gameManagerData = SaveSystem.Load<GameManagerData>(fileName);
        gameManager.LoadGame(gameManagerData);
    }

    public static bool IsSaved()
    {
        return SaveSystem.IsFileExist(fileName);
    }
}
