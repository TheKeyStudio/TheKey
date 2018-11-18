using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Door : KeyboardInteractable
{
    
    [Header("連接到某場景")]
    public string nextScene;
    public Color color = Color.black;
    public float fadeDamp = 0.5f;

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.UpArrow;
        interactButton = "EnterDoor";
    }

    public void ToNextScene()
    {
        Debug.Log("Going to " + nextScene);
        LoadingScene.instance.FadeToScene(nextScene, color, fadeDamp);
    }

    protected void ToNextScene(string sceneName)
    {
        LoadingScene.instance.FadeToScene(sceneName, color, fadeDamp);
    }
}
