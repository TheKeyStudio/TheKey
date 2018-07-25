using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Wisp_conversition : Interactable {
    
    private void Start()
    {
        interactKey = KeyCode.Z;
      
    }

    public override void Interact()
    {
        base.Interact();
        Open();
    }
    void Open()
    {
       
        int LevelKey = GameManager.instance.stage1 + 1;
        string callMsg = "靈魂對話" + LevelKey.ToString();
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log(LevelKey);

    }


}
