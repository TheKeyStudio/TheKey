using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalController : MonoBehaviour {

    public TMP_Text displayText;

    public TerminalInputCommand[] inputCmds;
    public TerminalFiles[] files;

    private List<string> terminalLog = new List<string>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ListAllFiles()
    {
        string allFilesName = "";
        foreach(TerminalFiles file in files)
        {
            allFilesName += file.fileName + " ";
        }
        LogString(allFilesName);
    }

    public void LogString(string stringToAdd)
    {
        terminalLog.Add(stringToAdd + "\n");
    }

    internal void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", terminalLog.ToArray());

        displayText.text = logAsText;
    }
}
