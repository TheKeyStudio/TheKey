using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDataManager : MonoBehaviour {


    private Dictionary<string, int> eventDataDict = new Dictionary<string, int>();
    public int eventDataDictLength;

    private void Update()
    {
        eventDataDictLength = eventDataDict.Count;
    }


    public int GetDataOrNew(string key)
    {
        if (!eventDataDict.ContainsKey(key))
        {
            NewEventData(key, 0);
        }

        return eventDataDict[key];
    }

    public void SetDataOrNew(string key, int newValue)
    {
        if (!eventDataDict.ContainsKey(key))
        {
            NewEventData(key, 0);
        }

        eventDataDict[key] = newValue;
    }


    private void NewEventData(string key, int value)
    {
        eventDataDict.Add(key, value);
    }
}
