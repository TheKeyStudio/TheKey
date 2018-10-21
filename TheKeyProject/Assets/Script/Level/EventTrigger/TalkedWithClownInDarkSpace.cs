using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkedWithClownInDarkSpace : OnceTimeGameStart {
    public GameObject door;
    public GameObject clown;
    public override void DestorySelfIfDone()
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager.talkedWithClown && !gameManager.isFirstTimeGoIntoDarkSpace)
        {
            door.SetActive(true);
            Destroy(gameObject);
        }

        if(!gameManager.talkedWithClown && !gameManager.isFirstTimeGoIntoDarkSpace)
        {
            clown.SetActive(true);
        }
    }

    protected override void DoneTalking()
    {
        GameManager.instance.talkedWithClown = true;

        DestorySelfIfDone();
    }
}
