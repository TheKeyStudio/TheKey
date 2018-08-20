using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFallingTrigger : MonoBehaviour {

    public GameObject bookObject;
    private BookEventTrigger animationEventTrigger;

    private void Awake()
    {
        animationEventTrigger = bookObject.GetComponent<BookEventTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animationEventTrigger.FallingAnimationTrigger();
        }
    }
}
