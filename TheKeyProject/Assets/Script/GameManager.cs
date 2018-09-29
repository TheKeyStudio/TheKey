using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public readonly int totalStage = 3;
    [SerializeField] private int[] stages;
    //Dark space
    public bool isFirstTimeGoIntoDarkSpace;
    //stage1
    public bool stage1FirstTimeGoInto;
    private string currentSceneName; //Main 1 的出生點

    public bool game1 = false;                  //第一階段的關卡 全部破完 才能通往下一關;

    public bool level1FirstTimeGoInto { get; internal set; }

    public string CurrentSceneName
    {
        get
        {
            return currentSceneName;
        }
    }

    public void RefreshSceneName()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
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

    void DefaultSetting()
    {
        RefreshSceneName();
        stage1FirstTimeGoInto = false;
        level1FirstTimeGoInto = false;
        isFirstTimeGoIntoDarkSpace = true;
        stages = new int[totalStage];
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
}
