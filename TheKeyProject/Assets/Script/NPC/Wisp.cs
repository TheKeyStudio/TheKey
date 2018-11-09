using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public abstract class Wisp : Npc
{
    [Range(0.1f, 3f)] public float waveAmplitude = 0.5f;
    [Range(0.1f, 3f)] public float waveSpeed = 1f;

    float elapsedTime;
    float original_y;

    protected EventDataGetter eventDataGetter;

    public override void Init()
    {
        base.Init();
        original_y = transform.position.y;
        eventDataGetter = GetComponent<EventDataGetter>();
    }

    public override void Update()
    {
        base.Update();
        Floating();
    }
    
    private void Floating()
    {
        elapsedTime += Time.deltaTime;
        float x = transform.position.x;
        float y = (waveAmplitude * Mathf.Sin(waveSpeed * elapsedTime)) + original_y;
        transform.position = new Vector3(x, y, 0);
    }


}
