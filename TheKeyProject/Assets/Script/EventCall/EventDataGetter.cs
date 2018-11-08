using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataGetter : MonoBehaviour
{
    [SerializeField] string eventName;
    protected EventDataManager eventDataMgr;

    private void Awake()
    {
        eventDataMgr = GameManager.instance.EventDataManager;
    }

    public int GetData()
    {
        return eventDataMgr.GetDataOrNew(eventName);
    }
}
