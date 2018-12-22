using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour {
    private Button button;
    public Sprite onImg;
    public Sprite offImg;

    public bool on = true;
    public GameObject[] switchActiveObjs;

    private void Start()
    {
        button = GetComponent<Button>();
        SetImage();
    }

    public void Press()
    {
        on = !on;
        SetImage();
        SwitchAllObjsActive();
    }

    private void SwitchAllObjsActive()
    {
        foreach(GameObject obj in switchActiveObjs)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    public void SetImage()
    {
        if (on)
        {
            button.GetComponent<Image>().sprite = onImg;
        }
        else
        {
            button.GetComponent<Image>().sprite = offImg;
        }
    }
}
