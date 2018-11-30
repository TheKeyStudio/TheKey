using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/Help")]
public class HelpCmd : TerminalInputCommand
{
    [TextArea(10, 20)]
    public string explainText;
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        if (separatedInputWords.Length == 1)
        {
            controller.LogString(explainText);
            controller.ListAllCommands();
            setter.SetData();
        }
        else
        {
            controller.LogString("Help don't not support argurment", "red", "3");
        }
    }
}
