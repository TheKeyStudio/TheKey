using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class FirstTimeGoIntoDarkSpace : OnceTimeGameStart {
    public GameObject addtiveScene;

    public override void DestorySelfIfDone()
    {
        if (!GameManager.instance.isFirstTimeGoIntoDarkSpace)
        {
            addtiveScene.SetActive(true);
            Destroy(gameObject);
        }
    }

    protected override void DoneTalking()
    {
        GameManager.instance.isFirstTimeGoIntoDarkSpace = false;
        DestorySelfIfDone();
    }
}
