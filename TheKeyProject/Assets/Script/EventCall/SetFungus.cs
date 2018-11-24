using UnityEngine;
using Fungus;

public class SetFungus : EventDataTrigger
{
    public string[] msgReceiveName;

    [SerializeField]private int lastEventCode = -1;

    private void Update()
    {
        Init();
    }

    protected override void Init()
    {
        int eventCode = eventDataGetter.GetData();
        if (eventCode >= msgReceiveName.Length || eventCode < 0)
        {
            return;
        }
        CallFungus(eventCode);
    }

    private void CallFungus(int currentEventCode)
    {
        if(lastEventCode < currentEventCode)
        {
            Flowchart.BroadcastFungusMessage(msgReceiveName[currentEventCode]);
            lastEventCode = currentEventCode;
        }
    }
}
