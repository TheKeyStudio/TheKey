using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HintCardChest : KeyboardInteractable
{
    
    public GameObject chestUI;

    private Animator animator;

    [Header("Hint Card")]
    [SerializeField] private HintCard hintCard;

    public override void Init()
    {
        base.Init();
        interactKey = KeyCode.Z;
        animator = GetComponent<Animator>();
        
        if (hintCard.Unlocked)
        {
            animator.SetBool("Opened", true);
        }
    }

    public override void Interact()
    {
        base.Interact();
        if (!hintCard.Unlocked)
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

    public void CompareInputAndHintCode(TMP_InputField inputField)
    {
        string text = inputField.text;
        
        if(!hintCard.Unlocked && text.Equals(hintCard.HintCardCode, StringComparison.InvariantCultureIgnoreCase))
        {
            BookManager.instance.AddPage(hintCard.HintCardSprite);
            HintCardManager.instance.UnlockHintCard(hintCard.CodeName);
            hintCard.Unlocked = true;
            Destroy(gameObject);
            Debug.Log("Unlocked " + hintCard.HintCardCode);
        }
        else
        {
            Debug.Log("hint card not available" + hintCard.HintCardCode);
        }
        

    }
    
}
