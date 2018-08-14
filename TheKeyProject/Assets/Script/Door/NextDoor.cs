using Fungus;
using UnityEngine;

public class NextDoor : Door {
    public int doorNumber;
    
    public override void Interact()
    {
        /*
        base.Interact();
        int player_done_level = GameManager.instance.stage1;
        Debug.Log(player_done_level + ":" + doorNumber);
        if (player_done_level + 1 >= doorNumber)
        {
            Flowchart.BroadcastFungusMessage("關卡通關");
            ToNextScene();
        }
        else
        {
            Flowchart.BroadcastFungusMessage("關卡未通關");
        }
        */
    }
    
}
