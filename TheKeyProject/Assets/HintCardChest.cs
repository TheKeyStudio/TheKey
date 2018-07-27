using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintCardChest : Interactable {

    public HintCardList hintCards;
    public GameObject chestUI;

    private Animator animator;

    public override void Init()
    {
        interactKey = KeyCode.Z;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        Open();
    }

    public void Open()
    {
        animator.SetBool("Opened", true);
        chestUI.SetActive(true);
    }

    public void Close()
    {
        animator.SetBool("Opened", false);
        chestUI.SetActive(false);
    }

    public void CheckInputAndHint(TMP_InputField inputField)
    {
        string text = inputField.text;
        HintCard hintCard = FindHintCardsCode(text);
        if(hintCard != null && !hintCard.hasBeenTaken)
        {
            BookManager.instance.AddPage(hintCard);
            hintCard.hasBeenTaken = true;
        }
        else
        {
            Debug.Log("hint card not available" + hintCard);
        }

    }

    public HintCard FindHintCardsCode(string text)
    {
        HintCard found = null;
        foreach(HintCard hintCard in hintCards.itemList)
        {
            if (hintCard.code.Equals(text))
            {
                found = hintCard;
            }
        }
        return found;
    }
}
