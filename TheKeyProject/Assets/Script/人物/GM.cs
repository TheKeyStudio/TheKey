using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GM : Npc
{
    // Update is called once per frame
    public override void Interact()
    {
        base.Interact();
        Talk();
    }
    public override void Talk()
    {
        Flowchart.BroadcastFungusMessage("小丑流程");
    }





}
