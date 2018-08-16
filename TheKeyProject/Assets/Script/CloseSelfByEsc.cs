using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSelfByEsc : MonoBehaviour {
    Computer computer;
    public GameObject computerGameObj;

    private void Start()
    {
        computer = computerGameObj.GetComponent<Computer>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Escape) && isActiveAndEnabled)
        {
            computer.Close();
        }
	}
}
