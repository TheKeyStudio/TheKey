using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TerminalInput : MonoBehaviour {
    public TMP_InputField inputField;

    private TerminalController controller;
    private TabAutoFillInputText tabAutoFill;
    
	void Awake () {
        controller = GetComponent<TerminalController>();
        tabAutoFill = GetComponent<TabAutoFillInputText>();
        inputField.onEndEdit.AddListener(FilterStringInput);
	}

    private void Update()
    {
        if (PressedEnterKey())
        {
            inputField.ActivateInputField();
        }

        if (inputField.isFocused){
            HistoryKeyDown();
            AutoFillInputKeyDown();
        }
    }

    private void HistoryKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetNextHistory();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetPreviousHistory();
        }
    }

    private void AutoFillInputKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputField.text = tabAutoFill.Tabbed(inputField.text);
            inputField.MoveTextEnd(false);
        }
        else if (Input.anyKeyDown)
        {
            tabAutoFill.UnTabbed();
        }
    }

    private void SetPreviousHistory()
    {
        inputField.text = controller.GetPreviousHistory();
    }

    private void SetNextHistory()
    {
        inputField.text = controller.GetNextHistory();
    }

    void FilterStringInput(string userInput)
    {
        userInput = userInput.Trim();
        if(userInput!="" && PressedEnterKey())
        {
            AcceptStringInput(userInput);
        }
    }

    bool PressedEnterKey()
    {
        return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter);
    }

    void AcceptStringInput(string userInput)
    {
        controller.LogUserInputString(userInput);
        controller.DoInput(userInput);

        InputComplete();
    }

    private void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }

    public void SetInputFieldActive(bool flag)
    {
        inputField.enabled = flag;
    }
}
