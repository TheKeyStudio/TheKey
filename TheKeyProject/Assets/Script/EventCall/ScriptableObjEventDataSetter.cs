using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScriptableObjEventDataSetter{

    public int[] eventCodes;
    public string[] eventNames;
    
    public void SetData()
    {
        if(eventCodes == null || eventNames == null)
        {
            Debug.Log("EventCode or eventName is null");
            return;
        }

        EventDataManager eventDataMgr;
        eventDataMgr = GameManager.instance.EventDataManager;
        for (int i = 0; i < eventCodes.Length; i++)
        {
            eventDataMgr.SetDataOrNew(eventNames[i], eventCodes[i]);
        }
    }
}
