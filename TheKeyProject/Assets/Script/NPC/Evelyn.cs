using UnityEngine;
using Fungus;

public class Evelyn : Wisp {


    protected override void HookInteract()
    {
        int eventCode = eventDataGetter.GetData();
        string callMsg = "Evelyn" + eventCode.ToString();
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log("Calling Talk: " + callMsg);
    }
}
