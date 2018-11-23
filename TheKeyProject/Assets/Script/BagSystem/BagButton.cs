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
        }
        else
        {
            EscStack.instance.Pop();
        }
        book.SetActive(!book.activeSelf);
    }

    public void Close()
    {
        BagButtonOnClick();
    }
}
