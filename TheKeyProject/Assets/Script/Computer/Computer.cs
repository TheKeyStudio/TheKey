using UnityEngine;

public class Computer : Interactable {

    // Use this for initialization

    public GameObject question;
    
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
