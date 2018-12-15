using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCardPickUp : MonoBehaviour
{
    [SerializeField]private HintCard hintCard;
    public string itemGetMsgReceivedName = "ItemGet";
    public string itemGoneMsgReceivedName = "ItemGone";

    HintCardManager hintCardManager;

    public void Start()
    {
        hintCardManager = GameManager.instance.HintCardManager;
    }

    private void Update()
    {
        hintCard.Unlocked = hintCardManager.IsUnlocked(hintCard.CodeName);
    }

    public void Pickup()
    {
        if (!hintCard.Unlocked)
        {
            hintCardManager.UnlockHintCard(hintCard.CodeName);

            SaveSystemManager.Save();
            Flowchart.BroadcastFungusMessage(itemGetMsgReceivedName);
        }
        else
        {
            Flowchart.BroadcastFungusMessage(itemGoneMsgReceivedName);
        }
    }

    public bool IsUnlocked()
    {
        return hintCard.Unlocked;
    }
}
