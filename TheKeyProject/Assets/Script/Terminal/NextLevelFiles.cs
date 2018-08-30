using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terminal/Files/NextLevelFiles")]
public class NextLevelFiles : TerminalFiles
{
    public int stage; 

    public override void Open(TerminalController controller)
    {
        GameManager gameManager = GameManager.instance;
        gameManager.NextLevel(stage);
        controller.LogString("Opened " + (gameManager.GetStageLevel(stage) + 1).ToString());
    }
}
