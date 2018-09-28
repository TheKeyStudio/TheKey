using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Light_Fight : MonoBehaviour {

    public void OnMouseEnter()
    {
        Debug.Log("開始震動");
        Flowchart.BroadcastFungusMessage("燈光晃動");
    }
}

