using System;
using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void Init()
    {
        interactKey = KeyCode.Z;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
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
