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
        if (gameManager.GetCurrentLevel() < openLevel)
        {
            gameManager.NextLevel();
            controller.LogString("Opened " + (gameManager.GetCurrentLevel()).ToString());
        }
        else
        {
            controller.LogString("Already Opened.");
        }
    }
}
