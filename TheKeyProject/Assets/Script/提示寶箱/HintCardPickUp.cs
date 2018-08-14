using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCardPickUp : Interactable {

    [Header("Hint Card")]
    [SerializeField] private HintCard hintCard;

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
    }

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    private void Pickup()
    {
        if (!hintCard.Unlocked)
        {
            BookManager.instance.AddPage(hintCard.HintCardSprite);
            HintCardManager.instance.UnlockHintCard(hintCard.HintCardCode);
            hintCard.Unlocked = true;
            Debug.Log("Unlocked " + hintCard.HintCardCode);
        }
    }
}
