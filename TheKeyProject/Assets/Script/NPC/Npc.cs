using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : MonoBehaviour
{
    public Color originalColor;
    public SpriteRenderer spriteRenderer;
    public GameObject noticeIcon;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

    }

    public virtual void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Highlight();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        UnHighlight();
    }

    public virtual void Highlight()
    {
        //spriteRenderer.color = Color.yellow;
        noticeIcon.SetActive(true);
    }

    public virtual void UnHighlight()
    {
        //spriteRenderer.color = originalColor;
        noticeIcon.SetActive(false);
    }

    public abstract void Talk();
    
}
