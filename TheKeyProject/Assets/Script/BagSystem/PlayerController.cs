using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D playerRigid2D;

    [Range(0, 150)]
    public float xForce;

    public Interactable focus;
    // Use this for initialization
    void Start () {
        playerRigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float horizontalDirection = Input.GetAxis("Horizontal");
        playerRigid2D.AddForce(new Vector2(xForce * horizontalDirection, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            SetFocus(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RemoveFocus();
    }

    private void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefoucused();
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    private void RemoveFocus()
    {
        if(focus!=null)
            focus.OnDefoucused();
        focus = null;

    }
}
