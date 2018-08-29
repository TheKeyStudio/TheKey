using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/*
 * This class is low cohesion, need to refactor 
 * 
 */

public class SingleInputFieldGenerator : MonoBehaviour {
    

    public GameObject inputPrefab;
    public List<TMP_InputField> input_list = new List<TMP_InputField>();

    private string answer;
    private int currentIndex = 0;
    private bool locked = true;
    private bool isSolved = false;
    private bool endEdit = false;

    public bool IsSolved
    {
        get
        {
            isSolved = answer.Equals(GetInputListForStringFormat(), StringComparison.OrdinalIgnoreCase);
            CheckIsSolved();
            return isSolved;
        }
    }

    private void OnGUI()
    {
        if(input_list.Count > 0)
            locked = input_list[currentIndex].text.Length > 0;  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && !locked)
        {
            Delete();
        }
    }

    public void SetAnswer(string ans)
    {
        this.answer = ans;
        CreateSingleInputField(this.answer.Length);
    }
    

    private void CheckIsSolved()
    {
        if (isSolved)
        {
            DoneAnswer();
        }
    }

    private void CreateSingleInputField(int amount)
    {
        RemoveAllChild();
        for (int i = 0; i < amount; i++)
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

    private void RemoveAllChild()
    {
        foreach(Transform child in transform)
        {
            Debug.Log("Removing " + child.name);
            GameObject.Destroy(child.gameObject);
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
        input_list[currentIndex].readOnly = true;
        currentIndex--;
        ChangeActivateInputField();
        input_list[currentIndex].text = "";
    }

    public string GetInputListForStringFormat()
    {
        string inputAnswer = "";
        foreach (TMP_InputField aInput in input_list)
        {
            inputAnswer = string.Concat(inputAnswer, aInput.text);
        }
        return inputAnswer;
    }
    
    public void ChangeActivateInputField()
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

    public void SetActive(bool flag)
    {
        gameObject.SetActive(flag);
    }

    public void DisableAllInputField()
    {
        foreach(TMP_InputField inputfield in input_list)
        {
            inputfield.interactable = false;
        }
    }

    public void DoneAnswer()
    {
        input_list[input_list.Count - 1].onEndEdit.RemoveAllListeners();
        isSolved = true;
    }
}
