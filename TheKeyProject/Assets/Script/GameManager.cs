using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public bool stage1FirstTimeGoInto;

    public bool game1 = false;                  //第一階段的關卡 全部破完 才能通往下一關;
    public readonly int totalStage = 3;
    [SerializeField]private int[] stages;
    public bool isFirstTimeGoIntoDarkSpace;

    public bool level1FirstTimeGoInto { get; internal set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            stage1FirstTimeGoInto = false;
            level1FirstTimeGoInto = false;
            isFirstTimeGoIntoDarkSpace = true;
            stages = new int[totalStage];
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel(int stage)
    {
        int index = stage - 1;
        stages[index]++;
    }

    public int GetStageLevel(int stage)
    {
        int index = stage - 1;
        return stages[index];
    }

    
}
