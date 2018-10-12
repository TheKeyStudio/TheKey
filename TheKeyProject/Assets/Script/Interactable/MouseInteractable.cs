using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractable : Clickable2D{

    public float interactDistance = 3f;
    //This locked is important, because every Mouse interactable object will check is player until the
    //range of object, we need this lock to avoid all of the object being trigger in the same time.
    bool locked = true; 
    PlayerAuto playerAuto;
    Collider2D collider2d;

    protected virtual void Start()
    {
        playerAuto = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAuto>();
        collider2d = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (playerAuto.until && !locked)
        {
            playerAuto.until = false;
            locked = true;
            base.DoPointerClick();
            HookInteract();
        }
    }

    protected override void DoPointerClick()
    {
        locked = false;
        Debug.Log(collider2d.bounds.center.x);
        playerAuto.AutoMoveXTo(collider2d.bounds.center.x, interactDistance);
    }

    protected virtual void HookInteract()
    {

    }
}
