using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;


public class Wisp_conversition : Interactable {

    public GameObject noticeIcon;

    public override void Init()
    {
        interactKey = KeyCode.Z;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    float elapsedTime;
    public override void Update()
    {
        base.Update();
        elapsedTime += Time.deltaTime;
        float x = transform.position.x;
        float y = (3f * Mathf.Sin(0.8f * elapsedTime))  ;
        Debug.Log(transform.position.y);
        transform.position = new Vector3(x, y, 0);
    }

    public override void Interact()
    {
        base.Interact();
        Open();
    }
    void Open()
    {
       
        int LevelKey = GameManager.instance.stage1 + 1;
        string callMsg = "靈魂對話" + LevelKey.ToString();
        Flowchart.BroadcastFungusMessage(callMsg);
        Debug.Log(LevelKey);

    }

    public override void Highlight()
    {
        noticeIcon.SetActive(true);
        spriteRenderer.color = new Color32(179, 221, 112, 255);
    }

}
