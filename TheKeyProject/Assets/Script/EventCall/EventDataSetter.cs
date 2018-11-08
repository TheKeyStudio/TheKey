using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataSetter : MonoBehaviour
{
    [SerializeField] private int eventCode;
    [SerializeField] string eventName;
    protected EventDataManager eventDataMgr;

    private void Awake()
    {
        eventDataMgr = GameManager.instance.EventDataManager;
        SetData();
    }
    public void SetData()
    {
        eventDataMgr.SetDataOrNew(eventName, eventCode);
    }
}
