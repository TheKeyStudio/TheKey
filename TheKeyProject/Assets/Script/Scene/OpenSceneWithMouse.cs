using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSceneWithMouse : MouseInteractable {

    private LoadAndUnloadScene loadAndUnloadScene;


    protected override void Start()
    {
        base.Start();
        loadAndUnloadScene = GetComponent<LoadAndUnloadScene>();
    }
    protected override void HookInteract()
    {
        loadAndUnloadScene.Open();
    }
}
