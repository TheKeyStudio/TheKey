using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SingleInputFieldGenerator : MonoBehaviour {

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
            obj.transform.SetParent(transform, true);
            TMP_InputField tmp_input = obj.GetComponent<TMP_InputField>();
            tmp_input.onSelect.AddListener(delegate { OnSelect(); });
            tmp_input.onValueChanged.AddListener(delegate { OnValueChanged(tmp_input); });
            tmp_input.readOnly = true;
            input_list.Add(tmp_input);
        }
	}

    public void OnSelect()
    {
        if(currentIndex >= input_list.Count)
        {
            currentIndex = input_list.Count - 1;
        }
        else if(currentIndex < 0){
            currentIndex = 0;
        }
        input_list[currentIndex].readOnly = false;
        input_list[currentIndex].ActivateInputField();
    }

    public void OnValueChanged(TMP_InputField tmp_input)
    {
        if (tmp_input.text.Length == tmp_input.characterLimit)
        {
            currentIndex++;
            OnSelect();
        }
        Debug.Log("Current index: " + currentIndex);
        Debug.Log(tmp_input.text);
    }

    public void Delete()
    {
        if (input_list[currentIndex].text.Equals(""))
        {
            input_list[currentIndex].readOnly = true;
            currentIndex--;
        }
        OnSelect();
        input_list[currentIndex].text = "";
    }

    public void CheckAnswer()
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
        Debug.Log("Answer is " + isEqual);
    }
    
}
