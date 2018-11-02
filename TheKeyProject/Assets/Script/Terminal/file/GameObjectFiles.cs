using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/GameObjectFiles")]
public class GameObjectFiles : TerminalFiles
{
    public GameObject obj;
    public override void Open(TerminalController controller)
    {
        TerminalObjControl objControl = controller.ObjControl;
        objControl.ShowGameObj(obj);
    }

}
