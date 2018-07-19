using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour {

    public GameObject inventory;
    private bool active = false;

	public void BagButtonOnClick()
    {
        Debug.Log("Bag button clicked");
        active = !active;
        inventory.SetActive(active);
    }
}
