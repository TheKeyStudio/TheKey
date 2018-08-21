using EaseTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    public string startGameScene;
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


    public void ToNextScene()
    {
        Debug.Log("Going to " + startGameScene);
        SceneManager.LoadScene(startGameScene);
    }
}
