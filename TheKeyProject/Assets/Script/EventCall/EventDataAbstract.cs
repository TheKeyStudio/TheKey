using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventDataAbstract : MonoBehaviour {

    public string eventName;
    protected EventDataManager eventDataMgr;

    void Awake()
    {
        eventDataMgr = GameManager.instance.EventDataManager;
    }
}
