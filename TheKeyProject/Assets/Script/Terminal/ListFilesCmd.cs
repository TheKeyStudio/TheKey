using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/ListFiles")]
public class ListFilesCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        controller.ListAllFiles();
    }
}
