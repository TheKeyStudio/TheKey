using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCardPickUpMouse : MouseInteractable {

    private HintCardPickUp hintcardPickUp;


    protected override void Start()
    {
        base.Start();
        hintcardPickUp = GetComponent<HintCardPickUp>();
    }

    protected override void HookInteract()
    {
        hintcardPickUp.Pickup();
    }
}
