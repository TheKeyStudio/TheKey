using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GM : Npc
{
    //對話結束後會消失的NPC
    public string flowchartMsg;
    
    public override void Talk()
    {
        Flowchart.BroadcastFungusMessage(flowchartMsg);
    }





}
