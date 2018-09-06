using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Door : KeyboardInteractable
{
    
    [Header("連接到某場景")]
    public string nextScene;

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.UpArrow;
    }

    public void ToNextScene()
    {
        Debug.Log("Going to " + nextScene);
        LoadingScene.instance.FadeToScene(nextScene);
    }
}
