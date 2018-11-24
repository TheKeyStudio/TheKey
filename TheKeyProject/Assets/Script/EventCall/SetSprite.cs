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
        
        spriteRender.sprite = sprites[eventCode];
    }
}

