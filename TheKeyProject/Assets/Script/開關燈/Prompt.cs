using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prompt : Interactable
{               //提示圖案出現

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
    }

    public override void Interact()
    {
        base.Interact();
    }
}
