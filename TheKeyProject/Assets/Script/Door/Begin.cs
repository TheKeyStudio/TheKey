using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;
public class Begin : MonoBehaviour {
    [Header("連接到某場景")]
    public string nextScene;



    public void ToNextScene()
    {
        Flowchart.BroadcastFungusMessage("開始遊戲");
        Debug.Log("Going to " + nextScene);
        SceneManager.LoadScene(nextScene);
    }
}
