using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : OnceTimeTriggerEvent
{

    protected override void DoneTalking()
    {
        GameManager.instance.stage1level1FirstTimeGoInto = true;
        DestorySelfIfDone();
    }

    protected override void DestorySelfIfDone()
    {
        if (GameManager.instance.stage1level1FirstTimeGoInto)
        {
            Destroy(gameObject);
        }
    }
}
