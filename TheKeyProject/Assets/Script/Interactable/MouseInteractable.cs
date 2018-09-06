using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractable : Clickable2D{

    public float interactDistance = 3f;
    bool startMove = false;
    PlayerAuto playerAuto;
    Collider2D collider2d;

    private void Start()
    {
        playerAuto = PlayerAuto.instance;
        collider2d = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (playerAuto.until)
        {
            playerAuto.until = false;
            base.DoPointerClick();
        }
    }

    protected override void DoPointerClick()
    {
        Debug.Log(collider2d.bounds.center.x);
        playerAuto.AutoMoveXTo(collider2d.bounds.center.x, interactDistance);
    }
}
