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
            controller.LogString("<size=-3><color=red>Error: File Name not found.</color></size>");
            return;
        }

        if (pwdFile == null || pwdFile.hasPassword)
        {
            controller.LogString("<size=-3><color=red>Error: Password file not found.</color></size>");
            return;
        }

        if (!file.hasPassword)
        {
            controller.LogString("<size=-3><color=red>Error: This file doesn't need password.</color></size>");
            return;
        }

        string[] passwordTexts = pwdFile.content.Split('\n');
        controller.SetInputFieldActive(false);
        StartCoroutine(Loading(passwordTexts, file));
    }


    IEnumerator Loading(string[] passwordTexts, TerminalFiles file)
    {
        string startStr = "<size=-4>";
        string endStr = "</size>";
        bool found = false;
        foreach (string password in passwordTexts)
        {
            controller.LogString(startStr + "<color=white>Trying password: " + password + "</color>" + endStr);
            controller.DisplayLoggedText();
            Debug.Log(loadingTime);
            yield return new WaitForSeconds(loadingTime);
            if (password.Equals(file.password, System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Password Found");
                controller.LogString(startStr + "<color=yellow>Password Found: " + password + "</color>" + endStr);
                controller.DisplayLoggedText();
                cmd.SetData();
                found = true;
                break;
            }
            else
            {
                Debug.Log("Wrong Password");
                controller.LogString(startStr + "<color=red>Wrong Password.</color>" + endStr);
            }
            controller.DisplayLoggedText();
            loadingTime = Random.Range(0.3f, 1.2f);
        }
        controller.SetInputFieldActive(true);
        if (!found)
        {
            controller.LogString(startStr + "<color=yellow>Fail to brute force this file.</color>" + endStr);

        }
    }
}
