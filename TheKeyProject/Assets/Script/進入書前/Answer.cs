using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Answer : MonoBehaviour {
    public InputField testInput;

    public void Start()
    {
        
    }

    public void correct()
    {
        string input = testInput.text;
        
        if (input.Equals("hour"))
        {
            Flowchart.BroadcastFungusMessage("答對了");
        }
        else
        {
            Flowchart.BroadcastFungusMessage("答錯了");
        }

    }

}
