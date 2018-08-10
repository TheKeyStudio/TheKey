using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour {

    public GameObject cameraObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            cameraObject.SetActive(false);
        }
    }
}
