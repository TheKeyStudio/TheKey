using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TerminalInputCommand : ScriptableObject {
    public string keyword;
    [TextArea(5,20)]
    public string description;
    public ScriptableObjEventDataSetter setter;

    public abstract void Respond(TerminalController controller, string[] separatedInputWords);

}
