using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TerminalFiles : ScriptableObject {
    public string fileName = "New File";
    public Color fileNameColor = new Color(1f, 1f, 1f);
    public bool hasPassword = false;
    public string password = "passw0rd";

    public abstract void Open(TerminalController controller);
}
