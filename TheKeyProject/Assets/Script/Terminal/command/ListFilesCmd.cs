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
            TerminalFilesHandler filesHandler = controller.FilesHandler;
            string allFilesName = filesHandler.GetAllFilesNameByString();
            controller.LogString(allFilesName);
            setter.SetData();
        }
        else
        {
            string errorMsg = "List don't not support argurment"; 

            controller.LogString(errorMsg, "red", "3");
        }
    }
    
}
