using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteForceController: MonoBehaviour {
    private TerminalController controller;
    private float loadingTime = 0f;
    
    private void Start()
    {
        controller = GetComponent<TerminalController>();
        loadingTime = Random.Range(1f, 3f);
    }

    public void BruteForce(string fileName, string passwordFile)
    {
        TerminalFilesHandler fileHandler = controller.FilesHandler;
        TerminalFiles file = fileHandler.GetFileByName(fileName);
        TextFiles pwdFile = (TextFiles)fileHandler.GetFileByName(passwordFile);
        if (file == null)
        {
            controller.LogString("Error: File Name not found.");
            return;
        }

        if (pwdFile == null || pwdFile.hasPassword)
        {
            controller.LogString("Error: Password file not found.");
            return;
        }

        if (!file.hasPassword)
        {
            controller.LogString("Error: This file doesn't need password.");
            return;
        }

        string[] passwordTexts = pwdFile.content.Split('\n');
        StartCoroutine(Loading(passwordTexts, file));
    }


    IEnumerator Loading(string[] passwordTexts, TerminalFiles file)
    {
        string startStr = "<size=-4>";
        string endStr = "</size>";
        foreach (string password in passwordTexts)
        {
            controller.LogString(startStr + "Trying password: " + password + endStr);
            controller.DisplayLoggedText();
            Debug.Log(loadingTime);
            yield return new WaitForSeconds(loadingTime);
            if (password.Equals(file.password))
            {
                Debug.Log("Password Found");
                controller.LogString(startStr + "<color=red>Password Found: " + password + "</color>" + endStr);
                controller.DisplayLoggedText();
                break;
            }
            else
            {
                Debug.Log("Wrong Password");
                controller.LogString(startStr + "Wrong Password." + endStr);
            }
            controller.DisplayLoggedText();
            loadingTime = Random.Range(1f, 3f);
        }
    }
}
