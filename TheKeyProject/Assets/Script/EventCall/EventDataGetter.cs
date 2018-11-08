using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataGetter : EventDataAbstract
{
    public int GetData()
    {
        return eventDataMgr.GetDataOrNew(eventName);
    }

}
