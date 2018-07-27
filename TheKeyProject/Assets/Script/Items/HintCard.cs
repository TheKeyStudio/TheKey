using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public class HintCard {
    public string hintCardName = "New Hint Card";
    public string code;
    //public Regex regex = new Regex("morse.?code");
    public Sprite sprite = null;
    public bool hasBeenTaken = false;
}
