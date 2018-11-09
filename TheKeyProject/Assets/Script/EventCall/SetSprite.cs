using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSprite : MonoBehaviour {
    public Sprite[] sprites;

    private EventDataGetter eventDataGetter;
    private SpriteRenderer spriteRender;

    // Use this for initialization
    void Awake()
    {
        eventDataGetter = GetComponent<EventDataGetter>();
        spriteRender = GetComponent<SpriteRenderer>();
        Init();
    }

    private void Init()
    {
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
