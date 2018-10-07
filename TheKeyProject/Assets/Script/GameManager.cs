using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public readonly int totalStage = 3; //總共有三個階段
    [SerializeField] private int[] stages; //記錄每個階段的關卡，例如stages[0]儲存第一階段的關卡，stages[1]儲存第二階段的關卡
    [SerializeField] private bool[] stagesComplete;  //儲存每個stage是否完成，true為完成，false為未完成

    //Dark space
    public bool isFirstTimeGoIntoDarkSpace; //第一次進入DarkSpace

    //stage1
    public bool stage1FirstTimeGoInto; //第一次進入scene main1
    private string currentSceneName; //當前的SceneName，主要用於玩家位置的設定

    public bool stage1level1FirstTimeGoInto { get; internal set; } //第一階段第一關第一次進入

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
        stage1FirstTimeGoInto = false;
        stage1level1FirstTimeGoInto = false;
        isFirstTimeGoIntoDarkSpace = true;
        stages = new int[totalStage];
        stagesComplete = new bool[totalStage];
    }

    public void NextLevel(int stage)
    {
        int index = stage - 1;
        stages[index]++;
    }

    public int GetStageCurrentLevel(int stage)
    {
        int index = stage - 1;
        return stages[index] + 1;
    }

    public bool IsStageComplete(int stage)
    {
        int index = stage - 1;
        return stagesComplete[index];
    }

    public void SetStageComplete(int stage)
    {
        int index = stage - 1;
        stagesComplete[index] = true;
    }
}
