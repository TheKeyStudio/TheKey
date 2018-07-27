using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hint Card", menuName = "New Items/Hint Card List")]
public class HintCardList : ScriptableObject {

    public List<HintCard> itemList;
}
