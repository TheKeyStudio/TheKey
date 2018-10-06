using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/OpenFiles")]
public class OpenFilesCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        try
        {
            controller.OpenFile(separatedInputWords[1]);
        }
        catch
        {
            controller.LogString("\'open\' is unavaiable, please make sure you have input file name.");
        }
    }
}
