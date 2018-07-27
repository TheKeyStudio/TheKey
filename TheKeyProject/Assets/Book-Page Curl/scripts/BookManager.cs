using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour {

    public static BookManager instance;

    public List<HintCard> bookPages = new List<HintCard>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance)
        {
            Destroy(gameObject);
        }
    }


    public void AddPage(HintCard item)
    {   
        bookPages.Add(item);
        Debug.Log("Adding " + item.hintCardName);
    }
}
