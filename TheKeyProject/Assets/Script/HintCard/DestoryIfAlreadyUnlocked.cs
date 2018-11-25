using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryIfAlreadyUnlocked : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HintCard hintCard = GetComponent<HintCard>();
        if (hintCard.Unlocked)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
