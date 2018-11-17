using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class NextScene : MonoBehaviour {
    [Header("連接到某場景")]
    public string nextScene;
    public Color color = Color.black;
    public float fadeDamp = 0.5f;
    private LoadingScene loadingScene;

    private void Start()
    {
        loadingScene = LoadingScene.instance;
    }

    public void ToNextSceneWithFade()
    {
        Debug.Log("Going to " + nextScene);
        loadingScene.FadeToScene(nextScene,color,fadeDamp);
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
