using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalController : MonoBehaviour {

    public TMP_Text displayText;
    public TerminalInputCommand[] inputCmds;

    [TextArea(5, 99)]
    public string welcomeText;

    private TerminalFilesHandler filesHandler;
    private List<string> terminalLog = new List<string>();

    private void Start()
    {
        LogString(welcomeText);
        DisplayLoggedText();
    }

    private void Awake()
    {
        filesHandler = GetComponent<TerminalFilesHandler>();
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
}
