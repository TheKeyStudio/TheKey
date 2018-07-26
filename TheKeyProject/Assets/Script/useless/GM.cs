using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GM : Interactable
{

    public override void Init()
    {
        interactKey = KeyCode.Z;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    public override void Interact()
    {
        base.Interact();
        Open();
    }
    void Open()
    {

       
        Flowchart.BroadcastFungusMessage("小丑流程");
        
    }





}
