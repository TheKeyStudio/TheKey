using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleInputFieldGenerator : MonoBehaviour {

    public int numberOfField;
    public GameObject inputPrefab;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < numberOfField; i++)
        {
            GameObject obj = Instantiate(inputPrefab) as GameObject;
            obj.transform.SetParent(transform, true);
            obj.transform.position = new Vector2(transform.position.x + i + 3, transform.position.y);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
