using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour {

    public GameObject book;

	public void BagButtonOnClick()
    {
        Debug.Log("Book button clicked");
        if (!book.activeSelf)
        { 
            Time.timeScale = 0;
            Debug.Log("Pause");
        }
        else
        {
            Time.timeScale = 1;
            Debug.Log("Resume");
        }
        book.SetActive(!book.activeSelf);
    }
}
