using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EaseTools;

public class BookManager : MonoBehaviour {

    public EaseUI component;
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

    public void PlayAnimation()
    {
        Debug.Log("Playing book animation");
        component = GameObject.Find("BookButton").GetComponent<EaseUI>();
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        component.ScaleIn();
        while (component.IsScaling())
        {
            yield return null;
        }
        component.ScaleOut();
    }
}
