using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class LibraryBook : MonoBehaviour
{
    public Flowchart flowchart;
    public string nextScene;

    // Update is called once per frame
    public void Update()
    {
        if (flowchart.GetBooleanVariable("isDone"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    
}
