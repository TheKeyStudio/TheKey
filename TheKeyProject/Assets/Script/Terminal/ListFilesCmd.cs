using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/ListFiles")]
public class ListFilesCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        if(separatedInputWords.Length == 1)
        {
            controller.ListAllFiles();
        }
        else
        {
            string errorMsg = "\"List\"  have not \"" + 
                separatedInputWords[1].ToString() + 
                "\" argument, please enter \"help list\" to see more"; 

            controller.LogString(errorMsg);
        }
    }
}
