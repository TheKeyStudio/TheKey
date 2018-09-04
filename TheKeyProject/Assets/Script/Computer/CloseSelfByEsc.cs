using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSelfByEsc : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Escape) && isActiveAndEnabled)
        {
            gameObject.SetActive(false);
        }
	}
}
