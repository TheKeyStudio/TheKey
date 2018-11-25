using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalController : MonoBehaviour {

    private EscStack escStack;
    private TerminalObjControl objControl;
    private TerminalFilesHandler filesHandler;
    private TerminalImageControl imageControl;
    private BruteForceController bruteForceCtrler;
    private TerminalInput terminalInput;
    private InputHistory inputHistory;
    private InputStrategy inputStrategy;
    private List<string> terminalLog = new List<string>();

    public TerminalInputCommand[] inputCmds;

    public TMP_Text displayText;

    [TextArea(5, 99)]
    public string welcomeText;


    private void Start()
    {
        LogString(welcomeText);
        DisplayLoggedText();
    }

    private void Awake()
    {
        escStack = EscStack.instance;
        objControl = GetComponent<TerminalObjControl>();
        filesHandler = GetComponent<TerminalFilesHandler>();
        imageControl = GetComponent<TerminalImageControl>();
        terminalInput = GetComponent<TerminalInput>();
        bruteForceCtrler = GetComponent<BruteForceController>();
        inputStrategy = new CommandInput();
    }

    internal void ListAllCommands()
    {
        List<string> allCommandsKeyword = new List<string>();
        foreach(TerminalInputCommand cmd in inputCmds)
        {
            allCommandsKeyword.Add("<size=-3><color=yellow>" + cmd.keyword + 
                "</color> - <color=white>" + cmd.description + "</color></size>");
        }
        string logAsText = string.Join("\n", allCommandsKeyword.ToArray());
        LogString(logAsText);
    }

    internal InputStrategy InputStrategy
    {
        get
        {
            return inputStrategy;
        }

        set
        {
            inputStrategy = value;
        }
    }

    public TerminalFilesHandler FilesHandler
    {
        get
        {
            return filesHandler;
        }
    }

    public TerminalImageControl ImageControl
    {
        get
        {
            return imageControl;
        }
    }

    public BruteForceController BruteForceCtrler
    {
        get
        {
            return bruteForceCtrler;
        }
    }

    public TerminalObjControl ObjControl
    {
        get
        {
            return objControl;
        }
    }

    public void LogString(string stringToAdd)
    {
        terminalLog.Add(stringToAdd);
    }

    public void LogUserInputString(string stringToAdd)
    {
        terminalLog.Add("$> " + stringToAdd);
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", terminalLog.ToArray());

        displayText.text = logAsText;

        ScrollToBottom();
    }

    public void ScrollToBottom()
    {
        RectTransform content = displayText.transform.parent.GetComponent<RectTransform>();
        Vector2 position = content.anchoredPosition;
        content.anchoredPosition = new Vector2(position.x, 0f);

    }

    public void DoInput(string userInput)
    {
        inputStrategy.DoInput(userInput, this);
    }

    public void InputPassword(string password)
    {
        filesHandler.CheckPasswordAndOpen(password);
    }

    public void SetInputFieldActive(bool flag)
    {
        terminalInput.SetInputFieldActive(flag);

    }

    public void InsertNewHistory(string newHistory)
    {
        if(inputHistory == null)
        {
            inputHistory = new InputHistory(newHistory);
        }
        else
        {
            inputHistory.InsertNewHistory(newHistory);
        }
    }

    public string GetNextHistory()
    {
        return inputHistory.GetNextHistory();
    }

    public string GetPreviousHistory()
    {
        return inputHistory.GetPreviousHistory();
    }

    public void ClearLog()
    {
        terminalLog.Clear();
        displayText.text = "";
    }

    public void Close()
    {
        escStack.Pop();
    }

    public List<string> GetAllCmdsNameByArray()
    {
        List<string> allCmdsName = new List<string>();
        foreach (TerminalInputCommand cmd in inputCmds)
        {
            allCmdsName.Add(cmd.keyword);
        }

        return allCmdsName;
    }

}
