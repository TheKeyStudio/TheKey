using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : Door
{
    public int passNumber;
    [SerializeField] private int stageNumber;
    [SerializeField]private int doorNumber;

    public override void Init()
    {
        base.Init();
        doorNumber = GameManager.instance.GetStageLevel(stageNumber) + 1;
    }

    public override void Interact()
    {
        base.Interact();
        if(doorNumber < passNumber)
        {
            nextScene = stageNumber.ToString() + "-" + doorNumber.ToString();
            Debug.Log("To next scene : " + nextScene);
            ToNextScene();
        }
    }
}
