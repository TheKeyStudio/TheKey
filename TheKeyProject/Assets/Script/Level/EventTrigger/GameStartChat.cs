using UnityEngine;

public class GameStartChat : ChatEvent {

    protected override void Start()
    {
        base.Start();
        ChatTrigger();
    }

    protected override void DoneTalking()
    {
        return;
    }
}
