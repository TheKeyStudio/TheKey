using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneLong : MonoBehaviour {

    public string sceneName;

    private void Start()
    {
        LoadLevel();
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
        yield return new WaitForSeconds(2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
    }
}
