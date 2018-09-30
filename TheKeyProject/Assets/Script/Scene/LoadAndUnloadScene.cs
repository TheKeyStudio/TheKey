using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndUnloadScene : MonoBehaviour {

    public string sceneName;

    bool opened = false;
    AddtiveSceneManager addtiveSceneMgr;

    // Use this for initialization
    void Start () {
        addtiveSceneMgr = AddtiveSceneManager.instance;
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && opened)
        {
            Close();
            opened = false;
        }
    }

    public void Open()
    {
        addtiveSceneMgr.LoadAndChangeActiveScene(sceneName);
        opened = true;
    }

    public void Close()
    {
        addtiveSceneMgr.RestoreLastActiveScene();
        addtiveSceneMgr.UnloadScene(sceneName);
    }
}
