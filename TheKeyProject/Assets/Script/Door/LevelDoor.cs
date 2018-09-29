using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : Door   
{
    public int passNumber;
    [SerializeField] private int stageNumber;
    private int currentLevel;

    public GameObject levelChooserObj;

    private LevelChooser levelChooser;

    public override void Init()
    {
        base.Init();
        levelChooser = levelChooserObj.GetComponent<LevelChooser>();
        currentLevel = GameManager.instance.GetStageCurrentLevel(stageNumber);
    }

    public override void Interact()
    {
        base.Interact();
        levelChooserObj.SetActive(true);
        levelChooser.AvailableButton(currentLevel);

    }

    public void ToLevel(int levelNumber)
    {
        if (levelNumber < passNumber)
        {
            nextScene = stageNumber.ToString() + "-" + levelNumber.ToString();
            Debug.Log("To next scene : " + nextScene);
            ToNextScene();
        }
    }
}
