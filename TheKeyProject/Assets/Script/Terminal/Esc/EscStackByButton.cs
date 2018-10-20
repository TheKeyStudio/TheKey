using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscStackByButton : MonoBehaviour {

    EscStack escStack;
	// Use this for initialization
	void Start () {
        escStack = EscStack.instance;
	}
	
	public void Close()
    {
        escStack.Pop();
    }
}
