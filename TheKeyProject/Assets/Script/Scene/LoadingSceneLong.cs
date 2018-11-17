using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneLong : MonoBehaviour {

    public string sceneName;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        StartCoroutine(LoadAsync(sceneName));
    }

	public void LoadLevel(string sceneName)
    {
        this.sceneName = sceneName;
        LoadLevel();
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}
