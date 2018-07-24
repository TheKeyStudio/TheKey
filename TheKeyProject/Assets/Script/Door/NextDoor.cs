using Fungus;

public class NextDoor : Door { 

    public override void Interact()
    {
        base.Interact();
        if (GameManager.instance.game1)
        {
            Flowchart.BroadcastFungusMessage("關卡一通關");
            ToNextScene();
        }
        else
        {
            Flowchart.BroadcastFungusMessage("關卡一未通關");
        }
    }
    
}
