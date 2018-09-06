using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInteractable : MonoBehaviour, Interactable{
    public KeyCode interactKey;
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
            Highlight();
            if (Input.GetKey(interactKey))
            {
                Interact();
            }
        }
        else
        {
            UnHighlight();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interating with " + transform.name);
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
    
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;

        playerController = player.GetComponent<PlayerController>();
    }

    public void OnDefoucused()
    {
        isFocus = false;
        player = null;
    }
}
