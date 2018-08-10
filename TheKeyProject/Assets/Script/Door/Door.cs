using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Door : Interactable {
    
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
        SceneManager.LoadScene(nextScene);
    }

    public void ToNextScene(string next)
    {
        Debug.Log("Going to " + next);
        SceneManager.LoadScene(next);
    }
}
