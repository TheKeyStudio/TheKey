using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour {

    public static BookManager instance;

    public List<Sprite> bookPages = new List<Sprite>();

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


    public void AddPage(Sprite bookpage)
    {   
        bookPages.Add(bookpage);
        Debug.Log("Adding " + bookpage.name);
    }
}
