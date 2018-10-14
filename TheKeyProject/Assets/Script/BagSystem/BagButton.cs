using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour {

    public GameObject book;
    PlayerController playerController;

    public void BagButtonOnClick()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        Debug.Log("Book button clicked");
        if (!book.activeSelf)
        {
            playerController.ReadBook(true);
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("Resume");
        }
        book.SetActive(!book.activeSelf);
    }
}
