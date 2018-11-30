using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookInObjectMouse : MouseInteractable {

    public string lookInObjectMsgReceivedName = "LookInObject";
    public string lookOutObjectMsgReceivedName = "LookOutObject";
    [Range(0f, 5f)]
    public float waitSec = 3f;

    private bool looking = false;
    private bool timeUp = false;

    protected override void Update()
    {
        base.Update();
        if(looking && Input.GetMouseButtonDown(0) && timeUp)
        {
            Flowchart.BroadcastFungusMessage(lookOutObjectMsgReceivedName);
            Debug.Log(lookOutObjectMsgReceivedName);
            looking = false;
            timeUp = false;
        }
    }

    protected override void HookInteract()
    {
        if (!looking)
        {
            Flowchart.BroadcastFungusMessage(lookInObjectMsgReceivedName);
            Debug.Log(lookInObjectMsgReceivedName);
            looking = true;
            StartCoroutine(WaitTime(waitSec));
        }
    }

    IEnumerator WaitTime(float time)
    {
        yield return new WaitForSeconds(time);
        timeUp = true;
    }
}
