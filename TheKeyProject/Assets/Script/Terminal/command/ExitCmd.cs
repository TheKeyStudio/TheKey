﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/InputCommand/Exit")]
public class ExitCmd : TerminalInputCommand
{
    public override void Respond(TerminalController controller, string[] separatedInputWords)
    {
        if (separatedInputWords.Length == 1)
        {
            setter.SetData();
            controller.Close();
        }
        else
        {
            controller.LogString("Exit don't not support argurment", "red", "3");
        }
    }
}
