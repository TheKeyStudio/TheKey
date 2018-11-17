using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Fungus;
using System;

public class Input1_7 : MonoBehaviour {
    public string answer;
    public TMP_InputField inputField;
    public Image img;
    
    public void Iscorrect()             //答案驗證
    {
        if (answer.Equals(inputField.text, StringComparison.InvariantCultureIgnoreCase))
        {
            Flowchart.BroadcastFungusMessage("strong_box_correct_answer");
            img.color = Color.green;
        }
        else
        {
            Flowchart.BroadcastFungusMessage("strong_box_wrong_answer");
        }
    }
}
