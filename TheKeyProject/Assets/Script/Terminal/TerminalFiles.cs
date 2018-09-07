using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TerminalFiles : ScriptableObject {
    public string fileName = "New File";
    public Color fileNameColor = new Color(0f, 1f, 0f);
    public abstract void Open(TerminalController controller);
}
