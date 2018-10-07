using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Terminal/Files/StageComplete")]
public class StageComplete : TerminalFiles
{
    public int completedStage;

    public override void Open(TerminalController controller)
    {
        GameManager gameManager = GameManager.instance;
        if (!gameManager.IsStageComplete(completedStage))
        {
            gameManager.NextLevel(completedStage);
            gameManager.SetStageComplete(completedStage);
            controller.LogString("Opened Stage " + (completedStage + 1) + ". Good luck kid.");
        }
        else
        {
            controller.LogString("Stage " + (completedStage + 1) + "is already opened for you.");
        }
    }
}
