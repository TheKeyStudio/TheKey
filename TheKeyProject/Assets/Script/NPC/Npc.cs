using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : Interactable {

    [SerializeField] protected bool talkAble;

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;

        ActiveTalk();
    }

    public void ActiveTalk()
    {
        talkAble = true;
    }

    public void DeactiveTalk()
    {
        talkAble = false;
    }

    public override void Interact()
    {
        base.Interact();

        if (talkAble)
        {
            Debug.Log("Talking with " + name);
            playerController.DeactiveMove(); //Probably use state pattern on playerController is better, like: Talking -> NoTalking
            DeactiveTalk();
            Talk();
        }
    }

    public abstract void Talk();
    
}
