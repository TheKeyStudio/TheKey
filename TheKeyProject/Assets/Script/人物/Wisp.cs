using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Wisp : Npc {

    public Flowchart flowchart;

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
        float y = (3f * Mathf.Sin(0.8f * elapsedTime)) + original_y;
        transform.position = new Vector3(x, y, 0);


        if (!flowchart.GetBooleanVariable("Talking"))
        {
            GameManager.instance.ActiveMove();
            Invoke("ActiveTalk", 2f); //延遲大約1.5秒才可再次對話
        }
    }
    
    public override void Talk()
    {
        int LevelKey = GameManager.instance.stage1 + 1;
        string callMsg = "靈魂對話" + LevelKey.ToString();
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log(LevelKey);

    }
    

}
