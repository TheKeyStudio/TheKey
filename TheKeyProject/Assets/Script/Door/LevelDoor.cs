using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : Door
{
    public int passNumber;
    [SerializeField]private int doorNumber;

    public override void Init()
    {
        base.Init();
        doorNumber = GameManager.instance.stage1 + 1;
    }

    public override void Interact()
    {
        base.Interact();
        if(doorNumber < passNumber)
        {
            string next = nextScene + doorNumber.ToString();
            Debug.Log("To next scene : " + next);
            ToNextScene(next);
        }
    }
}
