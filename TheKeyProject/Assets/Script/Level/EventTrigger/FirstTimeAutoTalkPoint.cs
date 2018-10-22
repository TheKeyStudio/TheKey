using UnityEngine;

public class FirstTimeAutoTalkPoint : OnceTimeTriggerEvent
{

    protected override void DoneTalking()
    {
        GameManager.instance.sawTheGhost = true;
        DestorySelfIfDone();
    }

    public override void DestorySelfIfDone()
    {
        if (GameManager.instance.sawTheGhost)
        {
            Destroy(gameObject);
        }
    }
}
