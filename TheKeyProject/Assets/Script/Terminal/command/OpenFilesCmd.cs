using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/OpenFiles")]
public class OpenFilesCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        controller.OpenFile(separatedInputWords[1]);
    }
}
