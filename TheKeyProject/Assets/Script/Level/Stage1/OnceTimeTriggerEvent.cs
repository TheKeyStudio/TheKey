using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnceTimeTriggerEvent : MonoBehaviour, Interactable
{
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
        if (flowChart.GetBooleanVariable("isDone"))
        {
            DoneTalking();
        }
    }

    protected abstract void DoneTalking();
    protected abstract void DestorySelfIfDone();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerController>();
            sound.source.Play();

            player.TriggerEvent(flowChart, this);
        }
    }


    public void Interact()
    {
        Flowchart.BroadcastFungusMessage(fungusMsgName);
    }
}
