using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour {

    public bool[] active;

    private EventDataGetter eventDataGetter;

    // Use this for initialization
    void Awake()
    {
        eventDataGetter = GetComponent<EventDataGetter>();
        Init();
    }

    private void Init()
    {
        int eventCode = eventDataGetter.GetData();
        if (eventCode >= active.Length || eventCode < 0)
        {
            return;
        }
        this.gameObject.SetActive(active[eventCode]);
    }
}
