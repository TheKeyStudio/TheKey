using Fungus;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeAutoTalkPoint : MonoBehaviour {
    
    public Flowchart flowChart;
    public string fungusMsgName;
    public Sound sound;

    PlayerController player;

    // Use this for initialization
    void Start () {
        DestorySelfIfDone();

        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
    }
	
	// Update is called once per frame
	void Update () {
		if (flowChart.GetBooleanVariable("isDone"))
        {
            DoneTalking();
            DestorySelfIfDone();
        }
	}

    private void DoneTalking()
    {
        player.ActiveMove();
        GameManager.instance.stage1FirstTimeGoInto = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            player.DeactiveMove();
            sound.source.Play();

            Flowchart.BroadcastFungusMessage(fungusMsgName);
        }
    }

    private void DestorySelfIfDone()
    {
        if (GameManager.instance.stage1FirstTimeGoInto)
        {
            Destroy(gameObject);
        }
    }
}
