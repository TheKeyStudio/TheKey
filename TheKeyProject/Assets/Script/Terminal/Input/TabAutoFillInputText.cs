using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabAutoFillInputText : MonoBehaviour {
    TerminalFilesHandler filesHandler;
    TerminalController controller;

    List<string> cmds;
    private List<string> files;
    List<string> foundItems;
    string[] separatedInputWords;
    private int currentIndex = 0;
    bool filling = false;

	// Use this for initialization
	void Start () {
        filesHandler = GetComponent<TerminalFilesHandler>();
        controller = GetComponent<TerminalController>();

        files = filesHandler.GetAllFilesNameByArray();
        cmds = controller.GetAllCmdsNameByArray();
	}
	
    public string Tabbed(string inputText)
    {
        if (!filling)
        {
            filling = true;
            FillInput(inputText);
        }
        Next();
        return string.Join(" ", separatedInputWords);
    }

    public void UnTabbed()
    {
        if (filling)
        {
            filling = false;
            currentIndex = 0;
        }
    }


    public void FillInput(string inputText)
    {
        char[] delimiterCharacters = { ' ' };
        separatedInputWords = inputText.Split(delimiterCharacters);
        int lastIndex = GetSeparatedInputWordsLastIndex();
        if (separatedInputWords.Length == 1)
        {
            separatedInputWords[lastIndex] = separatedInputWords[lastIndex].ToLower();
            foundItems = GetCmds(separatedInputWords[lastIndex]);
        }
        else
        {
            foundItems = GetFilesName(separatedInputWords[lastIndex]);
        }
        
    }

    private void Next()
    {
        if(separatedInputWords.Length != 0 && foundItems.Count != 0)
        {
            int lastIndex = GetSeparatedInputWordsLastIndex();
            separatedInputWords[lastIndex] = foundItems[currentIndex];
            currentIndex++;
            if(currentIndex == foundItems.Count)
            {
                currentIndex = 0;
            }
        }
        
    }

    private int GetSeparatedInputWordsLastIndex()
    {
        return separatedInputWords.Length - 1;
    }

    private List<string> GetCmds(string cmdTextToFill)
    {
        List<string> foundCmds = new List<string>();
        foreach(string cmd in cmds)
        {
            if(cmdTextToFill.Length <= cmd.Length)
            {
                if(cmd.Substring(0, cmdTextToFill.Length).Equals(cmdTextToFill))
                {
                    foundCmds.Add(cmd);
                }
            }
        }

        return foundCmds;
    }

    private List<string> GetFilesName(string fileNameToFill)
    {
        List<string> foundFiles = new List<string>();
        foreach(string file in files)
        {
            if(fileNameToFill.Length <= file.Length)
            {
                if(file.Substring(0, fileNameToFill.Length).Equals(fileNameToFill))
                {
                    foundFiles.Add(file);
                }
            }
        }

        return foundFiles;
    }
}
