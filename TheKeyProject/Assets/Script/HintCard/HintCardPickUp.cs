using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCardPickUp : MonoBehaviour
{
    private HintCard hintCard;
    public string itemGetMsgReceivedName = "ItemGet";
    public string itemGoneMsgReceivedName = "ItemGone";

    public void Start()
    {
        hintCard = GetComponent<HintCard>();
    }

    public void Pickup()
    {
        if (!hintCard.Unlocked)
        {
            BookManager.instance.AddPage(hintCard.HintCardSprite);
            BookManager.instance.AddPage(hintCard.HintCardDescriptSprite);
            HintCardManager.instance.UnlockHintCard(hintCard.HintCardCode);
            hintCard.Unlocked = true;
            Flowchart.BroadcastFungusMessage(itemGetMsgReceivedName);
        }
        else
        {
            Flowchart.BroadcastFungusMessage(itemGoneMsgReceivedName);
        }
    }
}
