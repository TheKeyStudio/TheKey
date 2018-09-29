using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddtiveSceneManager : MonoBehaviour {

    public static AddtiveSceneManager instance = null;
    public string[] DefaultScenesName;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        foreach(string sceneName in DefaultScenesName)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
