using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCardManager : MonoBehaviour {

    public static HintCardManager instance;

    [SerializeField]
    private List<HintCard> HintCards = new List<HintCard>();
    [SerializeField]
    private List<string> unlockedHintCardsCode = new List<string>();
    private List<HintCard> unlockedHintCards = new List<HintCard>();

    public List<string> UnlockedHintCardsCode
    {
        get
        {
            return unlockedHintCardsCode;
        }
    }

    public List<HintCard> UnlockedHintCards
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
        return unlockedHintCardsCode.Contains(hintCardCode);
    }

    public void UnlockHintCard(string hintCardCode)
    {
        HintCard hintCard = FindHintCardByCode(hintCardCode);
        if(hintCard != null)
        {
            unlockedHintCardsCode.Add(hintCardCode);
            unlockedHintCards.Add(hintCard);
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
