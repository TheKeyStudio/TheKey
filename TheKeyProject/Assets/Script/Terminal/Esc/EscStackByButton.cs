using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscStackByButton : MonoBehaviour {

    EscStack escStack;
	// Use this for initialization
	void Start () {
        escStack = EscStack.instance;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Close);
	}
	
	public void Close()
    {
        escStack.Pop();
    }
}
