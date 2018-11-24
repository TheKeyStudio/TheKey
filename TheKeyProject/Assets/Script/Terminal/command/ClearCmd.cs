using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/Clear")]
public class ClearCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        if (separatedInputWords.Length == 1)
        {
            controller.ClearLog();
            setter.SetData();
        }
        else
        {
            controller.LogString("Clear don't not support argurment");
        }
    }
}
