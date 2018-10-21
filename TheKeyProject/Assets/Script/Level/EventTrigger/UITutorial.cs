using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : OnceTimeTriggerEvent
{

    protected override void DoneTalking()
    {
        GameManager.instance.getTutorial = true;
        DestorySelfIfDone();
    }

    public override void DestorySelfIfDone()
    {
        if (GameManager.instance.getTutorial)
        {
            Destroy(gameObject);
        }
    }
}
