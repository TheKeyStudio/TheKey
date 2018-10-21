using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public abstract class ChatEvent : MonoBehaviour, Interactable
{
    [SerializeField] protected Flowchart flowChart;
    [SerializeField] protected string fungusMsgName;
    protected PlayerController player;

    // Use this for initialization
    protected virtual void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
    
    void Update()
    {
        if (flowChart.GetBooleanVariable("isDone"))
        {
            DoneTalking();
        }
    }

    public void ChatTrigger()
    {
        player.TriggerEvent(flowChart, this);
    }

    public void Interact()
    {
        Flowchart.BroadcastFungusMessage(fungusMsgName);
    }

    protected abstract void DoneTalking();
}
