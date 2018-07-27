using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour {

    public static BookManager instance;

    public List<Item> items = new List<Item>();

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


    public void Add(Item item)
    {   
        items.Add(item);
        Debug.Log("Adding " + item.name);
    }
}
