using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManagerData{
    public EventDataManagerMemento eventDataManager;
    public HintCardManagerDataMemento hintCardManager;
    public int totalLevel;
    public int level;
    public int terminalLogin;
    
    public bool isFirstTimeGoIntoDarkSpace;
    public bool talkedWithClown;
    
    public bool sawTheGhost;
    public bool getTutorial;
    
    public NpcData npcData;

    public string currentSceneName;
    

    public GameManagerData(GameManager gameManager)
    {
        eventDataManager = gameManager.EventDataManager.SaveMemento();
        hintCardManager = gameManager.HintCardManager.SaveMemento();
        totalLevel = gameManager.TotalLevel;
        level = gameManager.Level;
        terminalLogin = gameManager.TerminalLogin;

        isFirstTimeGoIntoDarkSpace = gameManager.isFirstTimeGoIntoDarkSpace;
        talkedWithClown = gameManager.talkedWithClown;

        sawTheGhost = gameManager.sawTheGhost;
        getTutorial = gameManager.getTutorial;

        npcData = gameManager.NpcData;

        currentSceneName = gameManager.CurrentSceneName;
    }
}
