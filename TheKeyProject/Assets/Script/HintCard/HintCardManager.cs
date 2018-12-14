using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCardManager : MonoBehaviour {

    public static HintCardManager instance;

    [SerializeField]
    private List<HintCard> HintCards = new List<HintCard>();
    [SerializeField]
    private List<string> unlockedHintCards = new List<string>();

    public List<string> UnlockedHintCards
    {
        get
        {
            return unlockedHintCards;
        }
    }

    private void Start()
    {
        foreach(HintCard card in HintCards)
        {
            card.Unlocked = false;
        }
    }

    public bool IsUnlocked(string hintCardCode)
    {
        return unlockedHintCards.Contains(hintCardCode);
    }

    public void UnlockHintCard(string hintCardCode)
    {
        HintCard hintCard = FindHintCardByCode(hintCardCode);
        if(hintCard != null)
        {
            BookManager.instance.AddPage(hintCard.HintCardSprite);
            BookManager.instance.AddPage(hintCard.HintCardDescriptSprite);
            unlockedHintCards.Add(hintCardCode);
            hintCard.Unlocked = true;
        }
    }

    public HintCardManagerDataMemento SaveMemento()
    {
        return new HintCardManagerDataMemento(this);
    }

    public void LoadMemento(HintCardManagerDataMemento memento)
    {
        foreach (string hintCard in memento.unlockedHintCards)
        {
            UnlockHintCard(hintCard);
        }
    }

    private HintCard FindHintCardByCode(string code)
    {
        HintCard found = null;
        foreach(HintCard card in HintCards)
        {
            if (card.CodeName.Equals(code))
            {
                found = card;
                break;
            }
        }
        return found;
    }
}
