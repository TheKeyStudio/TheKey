using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalFilesHandler : MonoBehaviour
{
    public TerminalFiles[] files;

    private TerminalFiles currentFile;
    private TerminalController controller;
    
    private void Awake()
    {
        controller = GetComponent<TerminalController>();
    }

    public string GetAllFilesName()
    {
        string allFilesName = "";
        foreach (TerminalFiles file in files)
        {
            allFilesName += file.fileName + " ";
        }
        return allFilesName;
    }

    public void Open(string fileName)
    {
        if (IsFileNameExist(fileName))
        {
            currentFile.Open(controller);
        }
        else
        {
            controller.LogString("\"" + fileName + "\"" + " doesn't exist");
        }
    }

    public bool IsFileNameExist(string fileName)
    {
        bool exist = false;
        foreach (TerminalFiles file in files)
        {
            if (file.fileName.Equals(fileName))
            {
                currentFile = file;
                exist = true;
            }
        }
        return exist;
    }
    
}
