using UnityEngine;

public class NormalDoor : Door {
    

    public override void Interact()
    {
        base.Interact();
        ToNextScene();
    }
}
