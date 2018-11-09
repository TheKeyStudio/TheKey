using UnityEngine;
using Fungus;

public class Ben : Wisp {

    public override void Talk()
    {
        int eventCode = eventDataGetter.GetData();
        string callMsg = "Ben" + eventCode.ToString();
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log("Calling Talk: " + callMsg);
    }
}
