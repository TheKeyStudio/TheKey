using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerminalImageControl : MonoBehaviour {

    public Image image;
    private TerminalController controller;

    public void ShowImage(Sprite sprite, TerminalController controller)
    {
        this.controller = controller;
        controller.SetInputFieldActive(false);
        image.sprite = sprite;
        gameObject.SetActive(true);
    }

    public void CloseImage()
    {
        controller.SetInputFieldActive(true);
        gameObject.SetActive(false);
    }
}
