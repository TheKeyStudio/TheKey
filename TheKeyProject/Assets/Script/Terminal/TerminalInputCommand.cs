using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TerminalInputCommand : ScriptableObject {
    public string keyword;

    public abstract void Respond(TerminalController controller, string[] separatedInputWords);
}
