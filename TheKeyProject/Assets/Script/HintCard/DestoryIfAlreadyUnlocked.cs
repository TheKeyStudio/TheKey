using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryIfAlreadyUnlocked : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HintCardPickUp hintCard = GetComponent<HintCardPickUp>();
        if (hintCard.IsUnlocked())
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
