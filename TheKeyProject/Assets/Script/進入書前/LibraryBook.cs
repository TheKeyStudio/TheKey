using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class LibraryBook : Interactable
{
   

    // Use this for initialization
    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
    }

    // Update is called once per frame
   
    public override void Interact()
    {
        base.Interact();
            Flowchart.BroadcastFungusMessage("書本劇情");
        
    }
  


}
