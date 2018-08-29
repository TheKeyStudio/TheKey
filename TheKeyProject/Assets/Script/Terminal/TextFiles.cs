using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/TextFiles")]
public class TextFiles : TerminalFiles
{
    public override void Show()
    {
        Debug.Log("showing " + name);
    }
}
