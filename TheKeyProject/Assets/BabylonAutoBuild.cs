using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabylonAutoBuild : MonoBehaviour {
    public GameObject babylonPrefab;
	
	// Update is called once per frame
	void Update () {
        AutoBuildIfChildIsNull();
    }

    void AutoBuildIfChildIsNull()
    {
        if (transform.childCount == 0)
        {
            GameObject newBabylon = Instantiate(babylonPrefab, transform);
        }
    }
}
