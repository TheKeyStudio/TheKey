using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnceTimeTriggerEvent : ChatEvent, OnceTimeEvent
{
    public Sound sound;

    // Use this for initialization
    protected override void Start()
    {
        DestorySelfIfDone();

        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            sound.source.Play();

            ChatTrigger();
        }
    }

    public abstract void DestorySelfIfDone();
}
