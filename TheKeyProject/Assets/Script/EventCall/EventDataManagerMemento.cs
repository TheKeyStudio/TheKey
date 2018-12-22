using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventDataManagerMemento {
    public Dictionary<string, int> eventDataDict;

    public EventDataManagerMemento(EventDataManager eventDataMgr)
    {
        eventDataDict = eventDataMgr.EventDataDict;
    }
}
