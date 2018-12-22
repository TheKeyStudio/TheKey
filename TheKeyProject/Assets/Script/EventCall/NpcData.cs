[System.Serializable]
public class NpcData{
    
    private bool isNpcTalked = false;
    private int lastEventCode;

    public bool IsNpcTalked
    {
        get
        {
            return isNpcTalked;
        }

        set
        {
            isNpcTalked = value;

            SaveSystemManager.Save();
        }
    }

    public int LastEventCode
    {
        get
        {
            return lastEventCode;
        }

        set
        {
            lastEventCode = value;

            SaveSystemManager.Save();
        }
    }
}
