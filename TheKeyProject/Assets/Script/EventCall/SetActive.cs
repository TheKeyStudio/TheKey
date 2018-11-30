using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : EventDataTrigger {

    public bool[] active;

    protected override void Init()
    {
        int eventCode = eventDataGetter.GetData();
        if (eventCode >= active.Length || eventCode < 0)
        {
            return;
        }
        Debug.Log("Setting active: " + active[eventCode]);
        this.gameObject.SetActive(active[eventCode]);
    }
}
