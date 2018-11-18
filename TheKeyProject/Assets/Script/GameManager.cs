using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    [SerializeField] private EventDataManager eventDataManager;
    [SerializeField] private int totalLevel;
    [SerializeField] private int level = 1; //記錄每個關卡是否已經被解了，例如第一關解題成功，level = 0 + 1。從1開始是因為1-1沒有Terminal Login
    [SerializeField] private int terminalLogin = 0; //記錄每個Terminal Login，初始值為0

    //Dark space
    public bool isFirstTimeGoIntoDarkSpace = true; //第一次進入DarkSpace
    public bool talkedWithClown = false;

    //Event
    public bool sawTheGhost = false; //在Main中看見靈魂的觸發事件
    public bool getTutorial = false; //在第一關第一次進入如觸發提醒


    [SerializeField] private string currentSceneName; //當前的SceneName，主要用於玩家位置的設定



    public string CurrentSceneName
    {
        get
        {
            return currentSceneName;
        }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            eventDataManager = GetComponent<EventDataManager>();
            DefaultSetting();
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }

    }

    public void RefreshSceneName()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    void DefaultSetting()
    {
        RefreshSceneName();
    }

    public void NextLevel()
    {
        level++;
    }

    public int GetCurrentLevel()
    {
        return level + 1;
    }

    public bool IsGameComplete()
    {
        return totalLevel == level;
    }
    
    public int TerminalLogin
    {
        get
        {
            return terminalLogin;
        }

        set
        {
            terminalLogin = value;
        }
    }

    public EventDataManager EventDataManager
    {
        get
        {
            Debug.Log("Get Event data manager");
            return eventDataManager;
        }
    }
}
