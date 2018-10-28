using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour {

    public GameObject settingObj;
    
	public void Open()
    {
        settingObj.active = true;
    }

    public void Close()
    {
        settingObj.active = false;
    }

    public void Exit()
    {
        Application.Quit();
    }



}
