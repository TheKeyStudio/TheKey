using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Door : Interactable {

    // Use this for initialization
    [Header("連接到某場景")]
    public string nextScene;

    public override void Init()
    {
        interactKey = KeyCode.UpArrow;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void ToNextScene()
    {
        Debug.Log("Going to " + nextScene);
        Inventory.instance.onItemChangedCallBack = null;
        SceneManager.LoadScene(nextScene);
    }
}
