using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EaseTools;
public class BagButton : MonoBehaviour, EscClose {

    public GameObject book;
    PlayerController playerController;

    public void BagButtonOnClick()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Debug.Log("Book button clicked");
        Debug.Log(book.activeSelf);
        if (!book.activeSelf)
        {
            EscStack.instance.Push(this);
            playerController.ReadBook();
            book.SetActive(true);
        }
        else
        {
            EscStack.instance.Pop();
        }
    }

    public void Close()
    {
        playerController.ReadBook();
        book.SetActive(false);
    }
    
}
