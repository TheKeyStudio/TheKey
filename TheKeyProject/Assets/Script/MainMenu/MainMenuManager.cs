using EaseTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public string sceneName;
    public Color color = Color.black;
    public float fadeDamp = 0.5f;

    public EaseUI easeComponent;
    private bool started = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!easeComponent.IsMoving() && started)
            ToNextScene();
    }

    public void StartGame()
    {
        easeComponent.MoveIn();
        started = true;
    }

    public void LoadGame()
    {
        SaveSystemManager.Load();
        sceneName = GameManager.instance.CurrentSceneName;
        StartGame();
    }

    public void ToNextScene()
    {
        Initiate.Fade(sceneName, color, fadeDamp);
    }
}
