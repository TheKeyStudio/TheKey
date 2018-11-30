using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteForceController: MonoBehaviour {
    private TerminalController controller;
    private BruteForceCmd cmd;
    private float loadingTime = 0f;
    
    private void Start()
    {
        controller = GetComponent<TerminalController>();
        loadingTime = Random.Range(1f, 3f);
    }

    public void BruteForce(string fileName, string passwordFile, BruteForceCmd cmd)
    {
        this.cmd = cmd;
        TerminalFilesHandler fileHandler = controller.FilesHandler;
        TerminalFiles file = fileHandler.GetFileByName(fileName);
        TextFiles pwdFile = (TextFiles)fileHandler.GetFileByName(passwordFile);
        if (file == null)
        {
            controller.LogString("Error: File Name not found.", "red", "3");
            return;
        }

        if (pwdFile == null || pwdFile.hasPassword)
        {
            controller.LogString("Error: Password file not found.", "red", "3");
            return;
        }

        if (!file.hasPassword)
        {
            controller.LogString("Error: This file doesn't need password.", "red", "3");
            return;
        }

        string[] passwordTexts = pwdFile.content.Split('\n');
        controller.SetInputFieldActive(false);
        StartCoroutine(Loading(passwordTexts, file));
    }


    IEnumerator Loading(string[] passwordTexts, TerminalFiles file)
    {
        bool found = false;
        foreach (string password in passwordTexts)
        {
            controller.LogString("Trying password: " + password, "red", "3");
            controller.DisplayLoggedText();
            Debug.Log(loadingTime);
            yield return new WaitForSeconds(loadingTime);
            if (password.Equals(file.password, System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Password Found");
                controller.LogString("Password Found: " + password, "yellow", "3");
                controller.DisplayLoggedText();
                cmd.SetData();
                found = true;
                break;
            }
            else
            {
                Debug.Log("Wrong Password");
                controller.LogString("Wrong Password.", "red", "3");
            }
            controller.DisplayLoggedText();
            loadingTime = Random.Range(0.3f, 1.2f);
        }
        controller.SetInputFieldActive(true);
        if (!found)
        {
            controller.LogString("Fail to brute force this file.", "yellow", "3");

            controller.DisplayLoggedText();
        }
    }
}
