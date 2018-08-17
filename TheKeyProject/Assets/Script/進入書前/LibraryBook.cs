using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class LibraryBook : Interactable
{
    public Flowchart flowchart;
    public string nextScene;
    // Use this for initialization
    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (flowchart.GetBooleanVariable("isDone"))
        {
            SceneManager.LoadScene(nextScene);
        }
        base.Update();
    }

    public override void Interact()
    {
        base.Interact();
        if (!flowchart.GetBooleanVariable("isDone"))
        {
            playerController.DeactiveMove();
            Flowchart.BroadcastFungusMessage("書本劇情");
        }
    }
}
