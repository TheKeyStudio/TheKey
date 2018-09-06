using UnityEngine;

public class Computer : KeyboardInteractable
{

    // Use this for initialization
    
    public GameObject question;

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
    }

    public override void Interact()
    {
        base.Interact();

        Open();
    }

    private void Open()
    {
        Debug.Log("Opening question: " + question.name);
        playerController.DeactiveMove();
        question.SetActive(true);
    }

    public void Close()
    {
        Debug.Log("Closing question: " + question.name);
        playerController.ActiveMove();
        question.SetActive(false);
    }
}
