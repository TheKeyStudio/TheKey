using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TerminalFiles : ScriptableObject {
    public string fileName = "New File";
    public abstract void Open(TerminalController controller);
}
