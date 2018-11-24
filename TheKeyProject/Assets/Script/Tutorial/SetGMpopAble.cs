using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGMpopAble : MonoBehaviour {
    
    public void ClosePop()
    {
        EscStack.instance.popAble = false;
    }

    public void OpenPop()
    {
        EscStack.instance.popAble = true;
    }
}
