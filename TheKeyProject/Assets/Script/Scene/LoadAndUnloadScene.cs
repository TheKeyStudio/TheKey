using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndUnloadScene : MonoBehaviour, EscClose {

    public string sceneName;
    
    AddtiveSceneManager addtiveSceneMgr;

    // Use this for initialization
    void Start () {
        addtiveSceneMgr = AddtiveSceneManager.instance;
    }

    public void Open()
    {
        addtiveSceneMgr.LoadAndChangeActiveScene(sceneName);
        EscStack.instance.Push(this);
    }

    public void Close()
    {
        addtiveSceneMgr.RestoreLastActiveScene();
        addtiveSceneMgr.UnloadScene(sceneName);
        Flowchart.BroadcastFungusMessage("取消");
    }
}
