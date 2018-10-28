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
            OpenCurrentFile();
        }
    }

    private void CheckFileNameExistAndChangeCurrent(string fileName)
    {
        TerminalFiles file = GetFileByName(fileName);
        if (GetFileByName(fileName) != null)
        {
            SetCurrentFile(file);
        }
        else
        {
            controller.LogString("\"" + fileName + "\"" + " doesn't exist");
            return;
        }
    }

    public TerminalFiles GetFileByName(string fileName)
    {
        TerminalFiles foundFile = null;
        foreach (TerminalFiles file in files)
        {
            if (file.fileName.Equals(fileName))
            {
                foundFile = file;
            }
        }
        return foundFile;
    }

    public void SetCurrentFile(TerminalFiles newFile)
    {
        currentFile = newFile;
    }

    public void CheckPasswordAndOpen(string password)
    {
        this.inputPassword = password;
        if (currentFile.password.Equals(password, StringComparison.OrdinalIgnoreCase))
        {
            OpenCurrentFile();
        }
        else
        {
            controller.LogString("Wrong password. Try again");
        }
        currentFile = null;
    }

    public void OpenCurrentFile()
    {
        currentFile.Open(controller);
    }
}
