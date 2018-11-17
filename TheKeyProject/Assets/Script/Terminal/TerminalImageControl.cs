using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalImageControl : MonoBehaviour, EscClose {

    public GameObject panel;
    private TerminalController controller;
    private GameObject imageObj;

    public void ShowImage(GameObject imagePrefab, TerminalController controller)
    {
        this.controller = controller;
        controller.SetInputFieldActive(false);
        imageObj = Instantiate(imagePrefab, panel.transform);
        panel.SetActive(true);
        EscStack.instance.Push(this);
    }

    public void Close()
    {
        controller.SetInputFieldActive(true);
        Destroy(imageObj);
        panel.SetActive(false);
        
    }
    
}
