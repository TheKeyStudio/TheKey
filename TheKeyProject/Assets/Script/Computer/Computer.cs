using UnityEngine;

public class Computer : Interactable {

    // Use this for initialization
    
    public GameObject question;

    public override void Init()
    {
        interactKey = KeyCode.Z;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public override void Interact()
    {
        base.Interact();

        Open();
    }

    private void Open()
    {
        Debug.Log("Opening question: " + question.name);
        GameManager.instance.playerStop();
        question.SetActive(true);
    }
}
