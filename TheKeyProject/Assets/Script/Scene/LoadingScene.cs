using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    public static LoadingScene instance;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    

    public void FadeToScene(string sceneName, Color color, float fadeDamp)
    {
        Initiate.Fade(sceneName, color, fadeDamp);
    }
    
}
