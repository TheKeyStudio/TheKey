using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnceTimeTriggerEvent : ChatEvent
{
    public Sound sound;


    // Use this for initialization
    void Start()
    {
        DestorySelfIfDone();

        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
    }


    protected abstract void DestorySelfIfDone();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            sound.source.Play();

            ChatTrigger();
        }
    }


    public override void Interact()
    {
        Flowchart.BroadcastFungusMessage(fungusMsgName);
    }
}
