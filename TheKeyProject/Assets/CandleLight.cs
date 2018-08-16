using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour {
    private Light light;
    private Color32 originalColor;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        originalColor = light.color;

    }
	
	// Update is called once per frame
	void Update () {
        int randomRed = Random.Range(originalColor.r, originalColor.r - 20);
        int randomGreen = Random.Range(originalColor.g, originalColor.g - 20);
        int randomBlue = Random.Range(originalColor.b, originalColor.b - 20);
        light.color = new Color32(randomRed, randomGreen, randomBlue, 255);
	}
}
