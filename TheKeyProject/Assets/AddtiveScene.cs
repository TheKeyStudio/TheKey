using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddtiveScene : MonoBehaviour {

    public string otherSceneName;

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene(otherSceneName, LoadSceneMode.Additive);
    }

}
