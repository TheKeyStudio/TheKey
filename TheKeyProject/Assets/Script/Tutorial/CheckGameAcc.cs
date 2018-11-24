using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameAcc : MonoBehaviour {
    public bool done = false;
	
	// Update is called once per frame
	void Update () {
        if (transform.Find("Information(Clone)") != null && !done)
        {
            GameUserInformation userInformation = transform.Find("Information(Clone)").GetComponent<GameUserInformation>();
            if (userInformation.accountText.text.Equals("benben79"))
            {
                EventDataSetter setter = GetComponent<EventDataSetter>();
                setter.SetData();
                done = true;
            }
        }
	}
}
