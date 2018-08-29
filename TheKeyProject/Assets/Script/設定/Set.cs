using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour {

    public GameObject gameObject;
    
	public void Open()
    {
        gameObject.active = true;
    }

    public void Close()
    {
        gameObject.active = false;
    }

    public void Exit()
    {
        Application.Quit();
    }



}
