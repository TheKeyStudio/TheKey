using UnityEngine;

public class SetPosition : EventDataTrigger {
    
    public Transform[] points;


    protected override void Init()
    {
        int eventCode = eventDataGetter.GetData();
        if (eventCode >= points.Length || eventCode < 0)
        {
            return;
        }

        this.transform.position = points[eventCode].position;
    }
}
