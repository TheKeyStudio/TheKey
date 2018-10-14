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
        playerController.ReadBook();
        book.SetActive(!book.activeSelf);
    }
}
