using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HindCardPickUpKeyboard : KeyboardInteractable
{
    
    private HintCardPickUp hintcardPickUp;
    

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
        hintcardPickUp = GetComponent<HintCardPickUp>();
    }

    public override void Interact()
    {
        base.Interact();
        Pickup();
    }

    private void Pickup()
    {
        hintcardPickUp.Pickup();
        UnHighlight();
        
    }
}
