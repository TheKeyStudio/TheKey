using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/NextLevelFiles")]
public class NextLevelFiles : TerminalFiles
{
    public int stage;
    public int openLevel;

    public override void Open(TerminalController controller)
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager.GetStageCurrentLevel(stage) < openLevel)
        {
            gameManager.NextLevel(stage);
            controller.LogString("Opened " + (gameManager.GetStageCurrentLevel(stage)).ToString());
        }
        else
        {
            controller.LogString("Already Opened.");
        }
    }
}
