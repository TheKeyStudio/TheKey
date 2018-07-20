using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GM : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("answer");
            if (active)
            {
                Flowchart.BroadcastFungusMessage("GM流程");
            }
        }
    }


    private bool active = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            active = true;
            Debug.Log(active);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("玩家"))
        {
            active = false;
            Debug.Log(active);
        }
    }

    



}
