using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDoor : Door {
    public string[] sceneNames;
    protected EventDataGetter eventDataGetter;
    int eventCode;

    public override void Init()
    {
        base.Init();
        eventDataGetter = GetComponent<EventDataGetter>();
    }

    public override void Update()
    {
        base.Update();
        eventCode = eventDataGetter.GetData();
    }

    public override void Interact()
    {
        base.Interact();
        ToNextScene(sceneNames[eventCode]);
    }
}
