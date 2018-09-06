using System;
using UnityEngine;

public class ItemPickup : KeyboardInteractable
{

    public Item item;

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
    }

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    private void Pickup()
    {
        Debug.Log("Picking up item: " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        Debug.Log("Was pickedup " + wasPickedUp);
        if (wasPickedUp)
            Debug.Log("Destorying " + item.name);
            Destroy(gameObject);
    }
}
