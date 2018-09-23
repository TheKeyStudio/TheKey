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
        string allFilesName = "Listed All files:\n";
        foreach (TerminalFiles file in files)
        {
            allFilesName += "* " + "<#" + ColorUtility.ToHtmlStringRGB(file.fileNameColor) + ">" +
                file.fileName + "</color>" + "\n";
        }
        return allFilesName;
    }

    public void Open(string fileName)
    {
        CheckFileNameExistAndChangeCurrent(fileName);
        if (currentFile.hasPassword)
        {
            controller.InputStrategy = new PasswordInput();
            controller.LogString("Please Enter password: ");
        }
        else
        {
            currentFile.Open(controller);
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
        if (currentFile.password.Equals(password))
        {
            currentFile.Open(controller);
        }
        else
        {
            controller.LogString("Wrong password. Try again");
        }
    }
}
