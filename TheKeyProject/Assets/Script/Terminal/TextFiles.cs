using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/TextFiles")]
public class TextFiles : TerminalFiles
{
    [TextArea(10, 99)]
    public string content = "New Content";

    public override void Open(TerminalController controller)
    {
        controller.LogString(content);
    }
}
