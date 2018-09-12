using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/Help")]
public class HelpCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        if (separatedInputWords.Length == 1)
        {
            controller.ListAllCommands();
        }
        else
        {

        }
    }
}
