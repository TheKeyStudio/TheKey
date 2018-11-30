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

    public string GetAllFilesNameByString()
    {
        List<string> allFilesName = new List<string>();
        allFilesName.Add("Listed All files:");
        foreach (TerminalFiles file in files)
        {
            allFilesName.Add("<size=-3>* " 
                + "<#" + ColorUtility.ToHtmlStringRGB(file.fileNameColor) + ">" +
                file.fileName + "</color></size>");
        }
        
        return string.Join("\n", allFilesName.ToArray());
    }

    public List<string> GetAllFilesNameByArray()
    {
        List<string> allFilesName = new List<string>();
        foreach (TerminalFiles file in files)
        {
            allFilesName.Add(file.fileName);
        }

        return allFilesName;
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
            controller.LogString("Please Enter password: ", "yellow", "2");
        }
        else
        {
            OpenCurrentFile();
        }
    }

    private void CheckFileNameExistAndChangeCurrent(string fileName)
    {
        TerminalFiles file = GetFileByName(fileName);
        if (file == null)
        {
            controller.LogString("<color=white>\"" + fileName + "\"</color>" + " doesn't exist", "red", "3");
        }
        SetCurrentFile(file);
    }

    public TerminalFiles GetFileByName(string fileName)
    {
        TerminalFiles foundFile = null;
        foreach (TerminalFiles file in files)
        {
            if (file.fileName.Equals(fileName, StringComparison.OrdinalIgnoreCase))
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
            controller.LogString("Wrong password. Please open the file and try again.", "red", "3");
        }
        currentFile = null;
    }

    public void OpenCurrentFile()
    {
        currentFile.Open(controller);
    }
}
