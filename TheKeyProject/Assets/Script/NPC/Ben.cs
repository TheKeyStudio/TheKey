using UnityEngine;
using Fungus;

public class Ben : Wisp {

    protected override void HookInteract()
    {
        int eventCode = eventDataGetter.GetData();
        string callMsg = "Ben" + eventCode.ToString();
        Debug.Log("Calling Talk: " + callMsg);
        Flowchart.BroadcastFungusMessage(callMsg);
    }
}
