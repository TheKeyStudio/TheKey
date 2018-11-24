using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/OpenFiles")]
public class OpenFilesCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        if(separatedInputWords.Length == 2)
        {
            TerminalFilesHandler filesHandler = controller.FilesHandler;
            filesHandler.Open(separatedInputWords[1]);
            setter.SetData();
        }
        else
        {
            controller.LogString("\'open\' is unavaiable, please make sure you have input file name.");
        }
    }
}
