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
            if (playerController.ReadBook())
            {
                EscStack.instance.Push(this);
                book.SetActive(true);
            }
        }
        else
        {
            EscStack.instance.Pop();
        }
    }

    public void Close()
    {
        if (playerController.ReadBook())
        {
            book.SetActive(false);
        }
    }
    
}
