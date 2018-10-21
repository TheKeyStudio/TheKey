using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInteractable : MonoBehaviour, Interactable{
    public KeyCode interactKey;
    public string interactButton;
    public Color originalColor;
    public SpriteRenderer spriteRenderer;
    public GameObject noticeIcon;

    bool isFocus = false;
    Transform player;
    protected PlayerController playerController;


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
        if (isFocus)
        {
            if (Input.GetButtonDown(interactButton))
            {
                Interact();
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interating with " + transform.name);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Highlight();
            isFocus = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        UnHighlight();
        isFocus = false;
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
    
}
