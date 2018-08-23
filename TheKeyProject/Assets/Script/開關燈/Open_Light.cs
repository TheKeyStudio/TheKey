using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class Open_Light : MonoBehaviour {

	// Use this for initialization
	public void Close()
    {
        Flowchart.BroadcastFungusMessage("關閉燈光");
    }
    public void Open()
    {
        Flowchart.BroadcastFungusMessage("打開燈光");
    }


}
