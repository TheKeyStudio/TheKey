using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalImageControl : MonoBehaviour, EscClose {

    public GameObject panel;
    private TerminalController controller;

    public void ShowImage(GameObject imagePrefab, TerminalController controller)
    {
        this.controller = controller;
        controller.SetInputFieldActive(false);
        GameObject image = Instantiate(imagePrefab, panel.transform);
        panel.SetActive(true);
        EscStack.instance.Push(this);
    }

    public void Close()
    {
        controller.SetInputFieldActive(true);
        panel.SetActive(false);
    }
    
}
