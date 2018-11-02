using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalObjControl : MonoBehaviour , EscClose
{
    private TerminalController controller;
    public Transform canvas;
    private GameObject current_obj;

    private void Start()
    {
        this.controller = GetComponent<TerminalController>();
    }

    public void ShowGameObj(GameObject obj)
    {
        controller.SetInputFieldActive(false);
        current_obj = Instantiate(obj, canvas);

        EscStack.instance.Push(this);
    }

    public void Close()
    {
        controller.SetInputFieldActive(true);
        Destroy(current_obj.gameObject);
    }
}
