using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fungus;

public class SingleInputFieldGenerator : MonoBehaviour {

    public int levelNumber;
    public string answer;
    public GameObject inputPrefab;

    public List<TMP_InputField> input_list;

    private int numberOfField;
    private int currentIndex = 0;

	// Use this for initialization
	void Start () {
        numberOfField = answer.Length;
        answer = answer.ToUpper();
        input_list = new List<TMP_InputField>();
		for(int i = 0; i < numberOfField; i++)
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
    
    public void CheckAnswer(GameObject obj)
    {
        bool isEqual = true;
        for(int i = 0; i < answer.Length; i++)
        {
            if (!input_list[i].text.Equals(answer[i].ToString()))
            {
                isEqual = false;
                break;
            }
        }
        if (isEqual)
        {
            GameManager.instance.stage1++;
            GameManager.instance.ActiveMove();
            Flowchart.BroadcastFungusMessage("答對了");
            obj.SetActive(false);
        }
        else
        {
            Flowchart.BroadcastFungusMessage("答錯了");
        }
        Debug.Log("Answer is " + isEqual);
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
