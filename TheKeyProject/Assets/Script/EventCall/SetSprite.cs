using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSprite : EventDataTrigger {

    public Sprite[] sprites;

    private SpriteRenderer spriteRender;

    protected override void Init()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        int eventCode = eventDataGetter.GetData();
        if (eventCode >= sprites.Length || eventCode < 0)
        {
            return;
        }

        while (sprites[eventCode] == null)
        {
            eventCode--;
            if (eventCode == 0)
            {
                break;
            }
        }
        spriteRender.sprite = sprites[eventCode];
    }
}

