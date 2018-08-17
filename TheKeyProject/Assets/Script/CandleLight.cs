using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour {
    private Light lighter;
    private float lightIntensity;
    private float timeTemp;

    [Range(0.5f, 3f)]
    public float lightVolunm = 0.1f;

    [Range(0.01f, 1f)]
    public float lightTime = 0.3f;

    [Range(0.01f, 1f)]
    public float lightRate = 0.2f;


    // Use this for initialization
    void Start () {
        lighter = GetComponent<Light>();
        lightIntensity = lighter.intensity;

        InvokeRepeating("StartEmitt", lightTime, lightRate);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timeTemp += Time.deltaTime;
    }

    private void StartEmitt()
    {

        if (lighter.intensity >= lightIntensity - lightVolunm)
        {
            lighter.intensity = lightIntensity - timeTemp + Random.Range(0f, lightIntensity - lighter.intensity);
        }
        else
        {
            lighter.intensity = Random.Range(lighter.intensity, lightIntensity);
            timeTemp = 0f;
        }
    }
}
