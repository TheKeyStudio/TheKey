using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalController : MonoBehaviour {

    public TMP_Text displayText;

    public TerminalInputCommand[] inputCmds;
    private InputStrategy inputStrategy;

    [TextArea(5, 99)]
    public string welcomeText;

    private TerminalFilesHandler filesHandler;

    internal void ListAllCommands()
    {
        string allCommandsKeyword = "";
        foreach(TerminalInputCommand cmd in inputCmds)
        {
            allCommandsKeyword += cmd.keyword + " - " + cmd.description + "\n";
        }
        LogString(allCommandsKeyword);
    }

    private List<string> terminalLog = new List<string>();

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

    private void Start()
    {
        LogString(welcomeText);
        DisplayLoggedText();
    }

    private void Awake()
    {
        filesHandler = GetComponent<TerminalFilesHandler>();
        inputStrategy = new CommandInput();
    }

    public void OpenFile(string fileName)
    {
        filesHandler.Open(fileName);
    }

    public void ListAllFiles()
    {
        string allFilesName = filesHandler.GetAllFilesName();
        LogString(allFilesName);
    }

    public void LogString(string stringToAdd)
    {
        terminalLog.Add(stringToAdd + "\n");
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", terminalLog.ToArray());

        displayText.text = logAsText;
    }

    public void DoInput(string userInput)
    {
        inputStrategy.DoInput(userInput, this);
    }

    public void inputPassword(string password)
    {
        filesHandler.CheckPasswordAndOpen(password);
    }

}
