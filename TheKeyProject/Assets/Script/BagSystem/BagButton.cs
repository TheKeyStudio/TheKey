using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour, EscClose {

    public GameObject book;
    PlayerController playerController;

    public void BagButtonOnClick()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Debug.Log("Book button clicked");
        playerController.ReadBook();
        Debug.Log(book.activeSelf);
        if (!book.activeSelf)
        {
            EscStack.instance.Push(this);
            book.SetActive(true);
        }
        else
        {
            EscStack.instance.Pop();
        }
    }

    public void Close()
    {
        book.SetActive(false);
    }
}
