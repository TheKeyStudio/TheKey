using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour, Interactable {
    public Flowchart flowChart;
    public string fungusMsgName;
    public Sound sound;

    PlayerController player;

    // Use this for initialization
    void Start()
    {
        DestorySelfIfDone();

        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DoneTalking()
    {
        GameManager.instance.stage1level1FirstTimeGoInto = true;
        DestorySelfIfDone();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            sound.source.Play();

            player.Interact(flowChart, this);
        }
    }

    private void DestorySelfIfDone()
    {
        if (GameManager.instance.stage1level1FirstTimeGoInto)
        {
            Destroy(gameObject);
        }
    }

    public void Interact()
    {
        Flowchart.BroadcastFungusMessage(fungusMsgName);
    }
}
