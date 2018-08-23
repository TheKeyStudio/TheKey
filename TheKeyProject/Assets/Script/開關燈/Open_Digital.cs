using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Open_Digital : Interactable
{

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
    }

    public override void Interact()
    {
        base.Interact();
        Debug.Log("有執行");
        Flowchart.BroadcastFungusMessage("數字鎖開啟");
    }


}
