using UnityEngine;
using Fungus;

public class Evelyn : Wisp {

    
    public override void Talk()
    {
        int eventCode = eventDataGetter.GetData();
        string callMsg = "Evelyn" + eventCode.ToString();
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log("Calling Talk: " + callMsg);
    }
}
