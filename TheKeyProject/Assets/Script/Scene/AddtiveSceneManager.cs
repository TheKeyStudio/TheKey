using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddtiveSceneManager : MonoBehaviour {

    public static AddtiveSceneManager instance = null;
    public string[] DefaultScenesName;

    private Scene lastActiveScene;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start () {
        lastActiveScene = SceneManager.GetActiveScene();
        foreach (string sceneName in DefaultScenesName)
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

    public void LoadAndChangeActiveScene(string sceneName)
    {
        StartCoroutine(LoadAsyncScene(sceneName));

    }

    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        ChangeActiveScene(sceneName);
    }

    public void ChangeActiveScene(string sceneName)
    {
        lastActiveScene = SceneManager.GetActiveScene();
        Scene newActiveScene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(newActiveScene);

    }

    public void RestoreLastActiveScene()
    {
        SceneManager.SetActiveScene(lastActiveScene);
    }
}
