using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCardManager : MonoBehaviour {

    public static HintCardManager instance;

    [SerializeField]
    private List<string> unlockedHintCards = new List<string>();


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

    public bool IsUnlocked(string hintCardCode)
    {
        return unlockedHintCards.Contains(hintCardCode);
    }

    public void UnlockHintCard(string hintCardCode)
    {
        unlockedHintCards.Add(hintCardCode);
    }
}
