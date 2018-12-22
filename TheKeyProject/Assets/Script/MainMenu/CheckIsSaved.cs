using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsSaved : MonoBehaviour {
    public GameObject unsavedObj;
    public GameObject savedObj;
	// Use this for initialization
	void Start () {
        if (SaveSystemManager.IsSaved())
        {
            unsavedObj.SetActive(false);
            savedObj.SetActive(true);
        }
        else
        {
            unsavedObj.SetActive(true);
            savedObj.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
