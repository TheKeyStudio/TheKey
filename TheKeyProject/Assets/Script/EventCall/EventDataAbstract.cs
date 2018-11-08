using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventDataAbstract : MonoBehaviour {

    public string eventName;

    void Awake()
    {
        Debug.Log("event data bstract");
    }
}
