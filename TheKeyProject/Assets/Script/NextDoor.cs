using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class NextDoor : Door { 
    public Flowchart flowchart;
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
  
    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && active)
        {
            if (gameManager.game1)
            {
                Flowchart.BroadcastFungusMessage("關卡一通關");
                toNextScene();
            }
            else
            {
                Flowchart.BroadcastFungusMessage("關卡一未通關");
            }
        }
    }
}
