using UnityEngine;

public abstract class TerminalFiles : ScriptableObject {
    public string fileName = "New File";
    public Color fileNameColor = new Color(1f, 1f, 1f);
    public bool hasPassword = false;
    public string password = "passw0rd";


    public int[] eventCodes;
    public string[] eventNames;

    public abstract void Open(TerminalController controller);

    protected void SetData()
    {
        EventDataManager eventDataMgr;
        eventDataMgr = GameManager.instance.EventDataManager;
        for (int i = 0; i < eventCodes.Length; i++)
        {
            eventDataMgr.SetDataOrNew(eventNames[i], eventCodes[i]);
        }
    }
}
