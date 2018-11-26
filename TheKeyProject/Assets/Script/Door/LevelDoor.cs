using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : Door, EscClose
{
    public int passNumber;
    [SerializeField] private int stageNumber;
    private int currentLevel;
    
    public GameObject levelChooserObj;

    private LevelChooser levelChooser;

    public override void Init()
    {
        base.Init();
        levelChooser = levelChooserObj.GetComponentInChildren<LevelChooser>();

        currentLevel = GameManager.instance.GetCurrentLevel();
    }
    

    public override void Interact()
    {
        base.Interact();
        levelChooserObj.SetActive(true);
        currentLevel = GameManager.instance.GetCurrentLevel();
        levelChooser.AvailableButton(currentLevel);
        EscStack.instance.Push(this);
    }

    public void ToLevel(int levelNumber)
    {
        if (levelNumber <= passNumber)
        {
            nextScene = "L" + stageNumber.ToString() + "-" + levelNumber.ToString();
            Debug.Log("To next scene : " + nextScene);
            ToNextScene();
        }
    }

    public void Close()
    {
        if(levelChooserObj == null)
        {
            return;
        }
        levelChooserObj.SetActive(false);
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.PlayerState = new Normal(playerController);
    }
}
