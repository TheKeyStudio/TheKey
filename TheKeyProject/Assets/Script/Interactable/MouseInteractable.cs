using Fungus;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInteractable : Clickable2D, Interactable{

    public float interactDistance = 3f;
    PlayerController playerController;
    Collider2D collider2d;

    protected virtual void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        collider2d = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
    }

    protected override void DoPointerClick()
    {
        Debug.Log(collider2d.bounds.center.x);
        playerController.AutoMoveToX(collider2d.bounds.center.x, interactDistance, this);
    }

    public void Interact()
    {
        base.DoPointerClick();
        HookInteract();
    }

    protected virtual void HookInteract()
    {

    }
    
}
