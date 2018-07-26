using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : Interactable {

    public GameObject noticeIcon;

    public override void Init()
    {
        interactKey = KeyCode.Z;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }
    
    public override void Interact()
    {
        base.Interact();
        Talk();
    }

    public abstract void Talk();

    public override void Highlight()
    {
        noticeIcon.SetActive(true);
        spriteRenderer.color = new Color32(179, 221, 112, 255);
    }

    public override void UnHighlight()
    {
        base.UnHighlight();
        noticeIcon.SetActive(false);
    }
}
