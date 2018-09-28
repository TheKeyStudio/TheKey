using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalFilesHandler : MonoBehaviour
{
    public TerminalFiles[] files;

    private TerminalFiles currentFile;
    private TerminalController controller;

    private string inputPassword;
    

    private void Awake()
    {
        controller = GetComponent<TerminalController>();
    }

    public string GetAllFilesName()
    {
        List<string> allFilesName = new List<string>();
        allFilesName.Add("Listed All files:");
        foreach (TerminalFiles file in files)
        {
            allFilesName.Add("* " + "<#" + ColorUtility.ToHtmlStringRGB(file.fileNameColor) + ">" +
                file.fileName + "</color>");
        }
        
        return string.Join("\n", allFilesName.ToArray());
    }

    public void Open(string fileName)
    {
        CheckFileNameExistAndChangeCurrent(fileName);
        if(currentFile == null)
        {
            return;
        }
        if (currentFile.hasPassword)
        {
            controller.InputStrategy = new PasswordInput();
            controller.LogString("Please Enter password: ");
        }
        else
        {
            OpenCurrentFileAndClear();
        }
    }

    private void CheckFileNameExistAndChangeCurrent(string fileName)
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

        if (!exist)
        {
            controller.LogString("\"" + fileName + "\"" + " doesn't exist");
            return;
        }
    }

    public void CheckPasswordAndOpen(string password)
    {
        this.inputPassword = password;
        if (currentFile.password.Equals(password, StringComparison.OrdinalIgnoreCase))
        {
            OpenCurrentFileAndClear();
        }
        else
        {
            controller.LogString("Wrong password. Try again");
        }
    }

    public void OpenCurrentFileAndClear()
    {
        currentFile.Open(controller);
        currentFile = null;
    }
}
