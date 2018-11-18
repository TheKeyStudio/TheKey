using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventDataTrigger : MonoBehaviour {

    protected EventDataGetter eventDataGetter;

    // Use this for initialization
    void Awake()
    {
        eventDataGetter = GetComponent<EventDataGetter>();
        Init();
    }

    protected abstract void Init();
}
