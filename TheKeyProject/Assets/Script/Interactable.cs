using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    public float radius = 3f;
    public KeyCode interactKey;
    public Color originalColor;
    public SpriteRenderer spriteRenderer;

    bool isFocus = false;
    Transform player;


    private void Start()
    {
        Init();
    }

    public abstract void Init();

    public virtual void Interact()                      
    {
        Debug.Log("Interating with " + transform.name);
    }

    public virtual void Highlight()
    {
        spriteRenderer.color = Color.yellow;
    }

    public virtual void UnHighlight()
    {
        spriteRenderer.color = originalColor;
    }

    public virtual void Update()
    {
        if (isFocus)
        {
            float distance = Vector2.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Highlight();
                if (Input.GetKey(interactKey))
                {
                    Interact();
                }
            }
        }
        else
        {
            UnHighlight();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
       
    }

    public void OnDefoucused()
    {
        isFocus = false;
        player = null;
       
    }
    


}
