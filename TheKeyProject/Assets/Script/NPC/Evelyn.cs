using UnityEngine;
using Fungus;

public class Evelyn : Wisp {


    protected override void HookInteract()
    {
        int eventCode = eventDataGetter.GetData();
        NpcData npcData = GameManager.instance.NpcData;
        string callMsg = "Evelyn" + eventCode.ToString();
        if (eventCode != npcData.LastEventCode)
        {
            npcData.IsNpcTalked = false;
        }

        if (!npcData.IsNpcTalked)
        {
            npcData.IsNpcTalked = true;
            npcData.LastEventCode = eventCode;
        }
        else
        {
            callMsg += "Talked";
        }
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log("Calling Talk: " + callMsg);
    }
}
