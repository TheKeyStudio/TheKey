using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddtiveScene : MonoBehaviour {

    public string[] otherScenesName;

	// Use this for initialization
	void Start () {
        foreach(string sceneName in otherScenesName)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

}
