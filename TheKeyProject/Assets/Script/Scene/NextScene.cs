using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class NextScene : MonoBehaviour {
    [Header("連接到某場景")]
    public string nextScene;

    public void ToNextScene()
    {
        Debug.Log("Going to " + nextScene);
        LoadingScene.instance.FadeToScene(nextScene);
    }
}
