using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartChat : ChatEvent {

    protected override void Start()
    {
        base.Start();
        ChatTrigger();
    }

    public override void Interact()
    {
        Flowchart.BroadcastFungusMessage(fungusMsgName);
    }

    protected override void DoneTalking()
    {
        return;
    }
}
