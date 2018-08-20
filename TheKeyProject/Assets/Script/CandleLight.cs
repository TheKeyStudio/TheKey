using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour {
    private Light lighter;
    private float originalIntensity;
    private float nextLightIntensity;
    public float smooth;

    [Range(0.5f, 3f)]
    public float lightVolunm = 1f;
    
    
    // Use this for initialization
    void Start () {
        lighter = GetComponent<Light>();
        originalIntensity = lighter.intensity;

        InvokeRepeating("RandomIntensity", 0.2f, 0.1f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartEmitt();
    }

    private void StartEmitt()
    {
        lighter.intensity = Mathf.Lerp(lighter.intensity, nextLightIntensity, smooth * Time.deltaTime);
        Debug.Log(nextLightIntensity);
    }

    private void RandomIntensity()
    {
        nextLightIntensity = Random.Range(lightVolunm, originalIntensity);
    }
}
