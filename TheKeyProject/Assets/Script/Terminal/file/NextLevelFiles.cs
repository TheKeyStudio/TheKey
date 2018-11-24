using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/NextLevelFiles")]
public class NextLevelFiles : TerminalFiles
{
    public int openLevel;

    public override void Open(TerminalController controller)
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager.GetCurrentLevel() < openLevel)
        {
            SetData();

            gameManager.NextLevel();
            controller.LogString("Next level is opened.");
        }
        else
        {
            controller.LogString("Already Opened.");
        }
    }

    
}
