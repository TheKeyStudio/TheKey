using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeAutoTalkPoint : OnceTimeTriggerEvent
{

    protected override void DoneTalking()
    {
        GameManager.instance.stage1FirstTimeGoInto = true;
        DestorySelfIfDone();
    }

    protected override void DestorySelfIfDone()
    {
        if (GameManager.instance.stage1FirstTimeGoInto)
        {
            Destroy(gameObject);
        }
    }
}
