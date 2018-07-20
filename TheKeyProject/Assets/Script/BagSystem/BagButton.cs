using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagButton : MonoBehaviour {

    public GameObject inventory;

	public void BagButtonOnClick()
    {
        Debug.Log("Bag button clicked");
        inventory.SetActive(!inventory.activeSelf);
    }
}
