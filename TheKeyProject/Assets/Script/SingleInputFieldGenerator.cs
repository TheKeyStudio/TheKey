using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

/*
 * This class is low cohesion, need to refactor 
 * 
 */

public class SingleInputFieldGenerator : MonoBehaviour {
    
    private class Answer
    {
        private int levelNumber;
        private string answerText;

        public Answer(int levelNumber, string answerText)
        {
            this.levelNumber = levelNumber;
            this.answerText = answerText.ToUpper();
        }

        public int GetAnswerLength()
        {
            return answerText.Length;
        }

        public bool CheckAnswerText(string inputAnswer)
        {
            return answerText.Equals(inputAnswer);
        }
    }

    [Header("Answer Information")]
    public int levelNumber;
    public string answerText;

    public GameObject inputPrefab;
    public List<TMP_InputField> input_list;
    public Computer computer;

    private Answer answer;
    private int currentIndex = 0;

	// Use this for initialization
	void Start () {
        answer = new Answer(levelNumber, answerText);
        input_list = new List<TMP_InputField>();
		for(int i = 0; i < answer.GetAnswerLength(); i++)
        {
            GameObject obj = Instantiate(inputPrefab) as GameObject;
            obj.transform.SetParent(transform, false);
            TMP_InputField tmp_input = obj.GetComponent<TMP_InputField>();
            tmp_input.onSelect.AddListener(delegate { OnSelect(); });
            tmp_input.onValueChanged.AddListener(delegate { OnValueChanged(tmp_input); });
            tmp_input.readOnly = true;
            input_list.Add(tmp_input);
        }
	}

    public void OnSelect()
    {
        if (input_list[currentIndex].text.Length == input_list[currentIndex].characterLimit)
        {
            Debug.Log("Current index: " + currentIndex);
            Debug.Log(input_list[currentIndex].text);
            currentIndex++;
        }
        ChangeActivateInputField();
    }

    public void OnValueChanged(TMP_InputField tmp_input)
    {
        tmp_input.text = tmp_input.text.ToUpper();
        OnSelect();
    }

    public void Delete()
    {
        if (input_list[currentIndex].text.Equals(""))
        {
            input_list[currentIndex].readOnly = true;
            currentIndex--;
        }
        ChangeActivateInputField();
        input_list[currentIndex].text = "";
    }
    
    public void CheckAnswer()
    {
        bool isEqual = answer.CheckAnswerText(GetInputListForStringFormat());
        
        if (isEqual && GameManager.instance.stage1 < levelNumber)
        {
            GameManager.instance.stage1++;
            Flowchart.BroadcastFungusMessage("答對了");
            computer.Close();
        }
        else
        {
            Flowchart.BroadcastFungusMessage("答錯了");
        }
        Debug.Log("Answer is " + isEqual);
    }

    private string GetInputListForStringFormat()
    {
        string inputAnswer = "";
        foreach (TMP_InputField aInput in input_list)
        {
            inputAnswer = string.Concat(inputAnswer, aInput.text);
        }
        return inputAnswer;
    }
    
    private void ChangeActivateInputField()
    {

        if (currentIndex >= input_list.Count)
        {
            currentIndex = input_list.Count - 1;
        }
        else if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        input_list[currentIndex].readOnly = false;
        input_list[currentIndex].ActivateInputField();
    }
}
