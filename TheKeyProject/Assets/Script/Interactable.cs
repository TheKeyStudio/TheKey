﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    bool isFocus = false;
    Transform player;                                 

   

    public virtual void Interact()                      
    {
        Debug.Log("Interating with " + transform.name);
    }

    private void FixedUpdate()
    {
        if (isFocus  && Input.GetKey(KeyCode.UpArrow))
        {
            float distance = Vector2.Distance(player.position, transform.position);
            if(distance <= radius)
            {
                Interact();
            }
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
