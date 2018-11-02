using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabylonSlot : Slot {
    public GameObject babylonPrefab;
	
	// Update is called once per frame
	void Update () {
        AutoBuildIfChildIsNull();
    }

    void AutoBuildIfChildIsNull()
    {
        if (Item == null)
        {
            Instantiate(babylonPrefab, transform);
        }
    }
}
