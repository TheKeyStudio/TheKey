using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnceTimeGameStart : ChatEvent, OnceTimeEvent
{
    protected override void Start()
    {
        DestorySelfIfDone();

        base.Start();
        ChatTrigger();
    }

    public abstract void DestorySelfIfDone();
    
}
