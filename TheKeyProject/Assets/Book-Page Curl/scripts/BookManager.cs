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

    public List<Sprite> GetBookPages()
    {
        HintCardManager hintCardManager = GameManager.instance.HintCardManager;
        Sprite temp = bookPages[0];
        bookPages.Clear();
        AddPage(temp);
        foreach(HintCard hintCard in hintCardManager.UnlockedHintCards)
        {
            AddPage(hintCard.HintCardSprite);
            AddPage(hintCard.HintCardDescriptSprite);
        }
        return bookPages;
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
