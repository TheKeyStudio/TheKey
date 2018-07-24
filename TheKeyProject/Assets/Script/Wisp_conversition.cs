using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Wisp_conversition : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            Debug.Log("sad");
            if (active)
            {
                Flowchart.BroadcastFungusMessage("關卡前");
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
