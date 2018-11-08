using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataSetter : EventDataAbstract
{
    public void SetData()
    {
        eventDataMgr.SetDataOrNew(eventName);
    }
}
