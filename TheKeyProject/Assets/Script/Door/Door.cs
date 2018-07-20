using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Door : Interactable {

    // Use this for initialization
    [Header("連接到某場景")]
    public string nextScene;
    
    public void ToNextScene()
    {
        Debug.Log("Going to " + nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
