using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Wisp : Npc {

    [Range(0.1f, 3f)] public float waveAmplitude = 0.5f;
    [Range(0.1f, 3f)] public float waveSpeed = 1f;

    //可以重複對話的NPC

    public Flowchart flowchart;
    public float talkCoolDownTime = 2f;
    public float startCoolDowmTime;

    float elapsedTime;
    float original_y;

    public override void Init()
    {
        base.Init();
        original_y = transform.position.y;
    }

    public override void Update()
    {
        base.Update();
        elapsedTime += Time.deltaTime;
        float x = transform.position.x;
        float y = (waveAmplitude * Mathf.Sin(waveSpeed * elapsedTime)) + original_y;
        transform.position = new Vector3(x, y, 0);

        if (!flowchart.GetBooleanVariable("Talking") && !talkAble)
        {
            startCoolDowmTime -= Time.deltaTime;
            playerController.ActiveMove();
            if (0 > startCoolDowmTime) //延遲大約x秒才可再次對話
                ActiveTalk();

        }

    }
    

    public override void Talk()
    {
        startCoolDowmTime = talkCoolDownTime;

        int LevelKey = GameManager.instance.GetStageCurrentLevel(1);
        string callMsg = "靈魂對話" + LevelKey.ToString();
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log(LevelKey);
    }
    

}
