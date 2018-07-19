using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class Door : MonoBehaviour {

    // Use this for initialization
    [Header("連接到某場景")]
    public string gototheScene;
    public bool active = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("玩家"))
        {
            active = true;
            Debug.Log(active);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            active = false;
            Debug.Log(active);
        }
    }


    public void toNextScene()
    {
        SceneManager.LoadScene(gototheScene);
    }
}
