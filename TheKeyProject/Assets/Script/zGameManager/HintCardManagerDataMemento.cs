using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HintCardManagerDataMemento{

    public List<string> unlockedHintCards;

    public HintCardManagerDataMemento(HintCardManager mgr)
    {
        unlockedHintCards = mgr.UnlockedHintCards;
    }

}
